using AuffEventsMobileService.DataObjects;
using AuffEventsMobileService.Providres;
using AuffEventsMobileService.Utils;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AuffEventsMobileService.Controllers
{
    public abstract class ImageTableController<TData> : TableController<TData> where TData : class, global::Microsoft.WindowsAzure.Mobile.Service.Tables.ITableData
    {
        protected string ImageFolder { get; set; }

        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<HttpResponseMessage> GetImage(string id)
        {
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                var blobStream = await new BlobStorageHelper(ImageFolder).OpenReadAsync(id);
                message.Content = new StreamContent(blobStream);
                message.Content.Headers.ContentLength = blobStream.Length;
            }
            catch (StorageException ex)
            {
                Services.Log.Error("Can not be retrieved from blob storage: " + ImageFolder + "/" + id, ex);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return message;
        }

        [HttpPost]
        public virtual async Task<HttpResponseMessage> PostImage(string id)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            try
            {
                MultipartStreamProvider provider = new BlobStorageMultipartStreamProvider(ImageFolder, id);
                await Request.Content.ReadAsMultipartAsync(provider);
            }
            catch (Exception ex)
            {
                Services.Log.Error("Can not be saved to blob storage: " + ImageFolder + "/" + id, ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        public virtual Task DeleteImage(string id)
        {
            return new BlobStorageHelper(ImageFolder).DeleteAsync(id);
        }
    }
}
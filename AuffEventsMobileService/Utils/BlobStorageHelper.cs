using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AuffEventsMobileService.Utils
{
    public class BlobStorageHelper
    {
        private string _folder;
        private CloudBlobContainer _blobContainer;

        public BlobStorageHelper(string folder = null)
        {
            _folder = folder ?? string.Empty;
            _blobContainer = InitBlobContainer();
        }

        private CloudBlobContainer InitBlobContainer()
        {
            var connectionString = ConfigurationManager.AppSettings["CloudStorageConnectionString"];
            var containerName = ConfigurationManager.AppSettings["CloudStorageContainer"];
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
            blobContainer.CreateIfNotExists();
            // Enable public access to blob
            //var permissions = blobContainer.GetPermissions();
            //if (permissions.PublicAccess == BlobContainerPublicAccessType.Off)
            //{
            //    permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
            //    blobContainer.SetPermissions(permissions);
            //}
            return blobContainer;
        }

        public Stream OpenWrite(string filePath)
        {
            CloudBlockBlob blob = _blobContainer.GetBlockBlobReference(Path.Combine(_folder, filePath));
            return blob.OpenWrite();
        }

        public async Task<Stream> OpenReadAsync(string filePath)
        {
            CloudBlockBlob blob = _blobContainer.GetBlockBlobReference(Path.Combine(_folder, filePath));
            var blobExists = await blob.ExistsAsync();
            if (!blobExists)
            {
                blob = _blobContainer.GetBlockBlobReference(Path.Combine(_folder, "no_picture"));
            }
            return await blob.OpenReadAsync();
        }

        public async Task DeleteAsync(string filePath)
        {
            CloudBlockBlob blob = _blobContainer.GetBlockBlobReference(Path.Combine(_folder, filePath));
            await blob.DeleteAsync(); 
        }
    }
}
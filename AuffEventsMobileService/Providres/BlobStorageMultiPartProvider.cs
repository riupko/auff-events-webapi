using AuffEventsMobileService.Utils;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace AuffEventsMobileService.Providres
{
    public class BlobStorageMultipartStreamProvider : MultipartStreamProvider
    {
        private string _folder;
        private string _fileName;

        public BlobStorageMultipartStreamProvider(string folder, string filePath) : base()
        {
            _folder = folder;
            _fileName = filePath;
        }

        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            Stream stream = null;
            ContentDispositionHeaderValue contentDisposition = headers.ContentDisposition;
            if (contentDisposition != null)
            {
                if (!String.IsNullOrWhiteSpace(contentDisposition.FileName))
                {
                    return new BlobStorageHelper(_folder).OpenWrite(_fileName);
                }
            }
            return stream;
        }
    }
}
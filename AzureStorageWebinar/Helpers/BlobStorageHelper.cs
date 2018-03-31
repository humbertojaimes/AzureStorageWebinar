using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureStorageWebinar.Helpers
{
    public class BlobStorageHelper
    {
        static async Task<CloudBlobContainer> GetContainer()
        {
            var account = CloudStorageAccount.Parse(Constants.StorageConnection);
            var client = account.CreateCloudBlobClient();

            var c = client.GetContainerReference("persons");
            await c.CreateIfNotExistsAsync();
            return c;
        }

        private static async Task<CloudBlobContainer> GetCloudBlobContainer(CloudBlobClient client, string container)
        {
            var c = client.GetContainerReference(container);
            await c.CreateIfNotExistsAsync();
            return client.GetContainerReference(container);
        }

        public static async Task<string> UploadFileAsync(Stream stream)
        {
            var container =  await GetContainer();

            string identifier = string.Format("{0}.jpg", Guid.NewGuid().ToString());
            var fileBlob = container.GetBlockBlobReference(identifier);

            await fileBlob.UploadFromStreamAsync(stream);

            var blobSAS = GetBlobSasUri(container,identifier);

            return fileBlob.Uri.ToString();
        }

        private static string GetContainerSasUri(CloudBlobContainer container, string storedPolicyName = null)
        {
            string sasContainerToken;

            if (storedPolicyName == null)
            {
                SharedAccessBlobPolicy adHocPolicy = new SharedAccessBlobPolicy()
                {
                    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
                    Permissions = SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.List
                };

                sasContainerToken = container.GetSharedAccessSignature(adHocPolicy, null);

            }
            else
            {
                 sasContainerToken = container.GetSharedAccessSignature(null, storedPolicyName);

            }

            return container.Uri + sasContainerToken;
        }

        private static string GetBlobSasUri(CloudBlobContainer container, string blobName, string policyName = null)
        {
            string sasBlobToken;

             CloudBlockBlob blob = container.GetBlockBlobReference(blobName);

            if (policyName == null)
            {
                SharedAccessBlobPolicy adHocSAS = new SharedAccessBlobPolicy()
                {
                    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
                    Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create
                };

                sasBlobToken = blob.GetSharedAccessSignature(adHocSAS);

            }
            else
            {
                sasBlobToken = blob.GetSharedAccessSignature(null, policyName);

            }

            return blob.Uri + sasBlobToken;
        }
    }
}

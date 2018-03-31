using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureStorageWebinar.Helpers
{
    public class TableStorageHelper
    {
        static async Task<Microsoft.WindowsAzure.Storage.Table.CloudTable> GetTable(string tableName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                Constants.StorageConnection);
            Microsoft.WindowsAzure.Storage.Table.CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            Microsoft.WindowsAzure.Storage.Table.CloudTable table = tableClient.GetTableReference(tableName);
            await table.CreateIfNotExistsAsync();
            return table;
        }


        public static async Task InsertInTable(Microsoft.WindowsAzure.Storage.Table.TableEntity newEntity, string tableName)
        {
            var table = await GetTable(tableName);
            var insertOperation = Microsoft.WindowsAzure.Storage.Table.TableOperation.Insert(newEntity);
            await table.ExecuteAsync(insertOperation);
        }

        public static async Task DeleteFromTable(Microsoft.WindowsAzure.Storage.Table.TableEntity newEntity, string tableName)
        {
            var table = await GetTable(tableName);
            var deleteOperation = Microsoft.WindowsAzure.Storage.Table.TableOperation.Delete(newEntity);
            await table.ExecuteAsync(deleteOperation);
        }

        public static async Task<List<TableEntity>> GetAll(string tableName)
        {
            List<TableEntity> result = new List<TableEntity>();

            var acc =  CloudStorageAccount.Parse(Constants.StorageConnection);
            var tableClient = acc.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableName);
            var query = new TableQuery();

            EntityResolver<Model.PersonEntity> personResolver = (pk, rk, ts, props, etag) =>
            {
                return new Model.PersonEntity(props["LastName"].StringValue, props["Name"].StringValue,props["PhotoUri"].StringValue );
            };

            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<Model.PersonEntity> resultSegment = await table.ExecuteQuerySegmentedAsync(query,personResolver, token);
                token = resultSegment.ContinuationToken;

                foreach (var entity in resultSegment.Results)
                {
                    result.Add(entity);
                }
            } while (token != null);

            return result;
        }
    }
}

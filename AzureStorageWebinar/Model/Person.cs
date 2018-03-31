using System;
namespace AzureStorageWebinar.Model
{
    public class PersonEntity : Microsoft.WindowsAzure.Storage.Table.TableEntity
    {
        public PersonEntity(string lastName, string name,string photoUri)
        {
            this.PartitionKey = "persons";
            this.RowKey = $"{name}{lastName}";
            Name = name;
            LastName = lastName;
            PhotoUri = photoUri;  
        }

        public PersonEntity() { }

        public string Name
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string PhotoUri
        {
            get;
            set;
        }
    }
}

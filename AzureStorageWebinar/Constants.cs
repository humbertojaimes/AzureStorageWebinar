using System;
namespace AzureStorageWebinar
{
    public enum ContainerType
    {
        Image,
        Text
    }

    public static class Constants
    {
        public const string StorageConnection = "DefaultEndpointsProtocol=https;AccountName=webinstorage;AccountKey=i7ZWfCfaZMg9+PC9zxRFOEMbt5ZM3HsDj+ohiBuhzSFa+KGFqNqr+oOgT7ZWvYb2Yn7lhloRQSlzPihvr9TFig==;EndpointSuffix=core.windows.net";
        //public const string StorageConnection = "UseDevelopmentStorage=true"; // Uncomment this connection string to use the Azure Storage emulator
    }
}

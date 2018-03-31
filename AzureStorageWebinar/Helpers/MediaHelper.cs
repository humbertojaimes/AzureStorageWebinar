using System;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;

namespace AzureStorageWebinar.Helpers
{
    public class MediaHelper 
    {
        public static async Task<byte[]> TakePhotoAsync()
        {
            byte[] photo = null;

            if (Plugin.Media.CrossMedia.Current.IsCameraAvailable
               && Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                    Directory = "People",
                    Name = "person.jpg",
                    MaxWidthHeight = 512,
                    AllowCropping = true,
                    RotateImage = true
                });

                if (file != null)
                    using (var photoStream = file.GetStream())
                    {
                        photo = new byte[photoStream.Length];
                        await photoStream.ReadAsync(photo, 0, (int)photoStream.Length);
                    }
            }

            return photo;
        }




    }
}


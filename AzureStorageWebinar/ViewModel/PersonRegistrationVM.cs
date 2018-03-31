using System;
using MvvmHelpers;
using System.Windows.Input;
using Xamarin.Forms;
using System.IO;

namespace AzureStorageWebinar.ViewModel
{
    public class PersonRegistrationVM:BaseViewModel
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged(); }
        }

        private byte[] photo;

        public byte[] Photo
        {
            get { return photo; }
            set { photo = value; OnPropertyChanged(); }
        }

        public ICommand TakePhotoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Photo = await Helpers.MediaHelper.TakePhotoAsync();
                });
            }
        }

        public ICommand SavePersonCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (IsBusy) return;
                    IsBusy = true;
                    var photoUri = await Helpers.BlobStorageHelper.UploadFileAsync(new MemoryStream(photo));
                    await Helpers.TableStorageHelper.InsertInTable(new Model.PersonEntity(lastName,name,photoUri),"person");
                    await Helpers.TableStorageHelper.GetAll("person");
                    IsBusy = false;
                });
            }
        }

    }
}

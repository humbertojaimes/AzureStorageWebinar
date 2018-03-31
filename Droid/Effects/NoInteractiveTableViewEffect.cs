using AzureStorageWebinar.Droid.Effects;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;


[assembly: ResolutionGroupName("Effects")]
[assembly: ExportEffect(typeof(NoInteractiveTableViewEffect), "NoInteractiveTableViewEffect")]
namespace AzureStorageWebinar.Droid.Effects
{
    public class NoInteractiveTableViewEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            // TODO: Apply your effect.
        }

        protected override void OnDetached()
        {
            // TODO: Remove your effect.
        }
    }
}

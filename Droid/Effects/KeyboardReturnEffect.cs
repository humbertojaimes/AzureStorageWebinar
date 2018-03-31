using AzureStorageWebinar.Droid.Effects;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;


[assembly: ResolutionGroupName("Effects")]
[assembly: ExportEffect(typeof(KeyboardReturnEffect), "KeyboardReturnEffect")]
namespace AzureStorageWebinar.Droid.Effects
{
    public class KeyboardReturnEffect : PlatformEffect
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

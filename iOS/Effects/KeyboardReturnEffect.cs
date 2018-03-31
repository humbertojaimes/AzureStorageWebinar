using AzureStorageWebinar.iOS.Effects;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;


[assembly: ExportEffect(typeof(KeyboardReturnEffect), "KeyboardReturnEffect")]
namespace AzureStorageWebinar.iOS.Effects
{
    public class KeyboardReturnEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control == null)
                return;

            var editText = Control as UIKit.UITextField;
            editText.ReturnKeyType = UIKit.UIReturnKeyType.Next;
        }

        protected override void OnDetached()
        {
            // TODO: Remove your effect.
        }
    }
}

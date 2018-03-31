using AzureStorageWebinar.iOS.Effects;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;

[assembly: ResolutionGroupName("Effects")]
[assembly: ExportEffect(typeof(NoInteractiveTableViewEffect), "NoInteractiveTableViewEffect")]
namespace AzureStorageWebinar.iOS.Effects
{
    public class NoInteractiveTableViewEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control == null)
                return;

            ((UITableView)Control).SeparatorStyle = UITableViewCellSeparatorStyle.None;
            ((UITableView)Control).AllowsSelection = false;
        }

        protected override void OnDetached()
        {
            // TODO: Remove your effect.
        }
    }
}

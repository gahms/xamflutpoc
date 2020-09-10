using System;
using Flutter;
using UIKit;

namespace xamflutpoc
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var flutterEngine = new FlutterEngine("");
            flutterEngine.Run();
            GeneratedPluginRegistrant.RegisterWithRegistry(flutterEngine);

            var vc = new FlutterViewController(flutterEngine, null, null);
            AddChildViewController(vc);
            View.AddSubview(vc.View);
            vc.View.Frame = new CoreGraphics.CGRect(
                View.Frame.Location.X, View.Frame.Location.Y,
                View.Frame.Size.Width, View.Frame.Size.Height / 2);
            vc.DidMoveToParentViewController(this);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void UIButton197_TouchUpInside(UIButton sender)
        {
            Console.WriteLine("Tapped!");

            var flutterEngine = new FlutterEngine("");
            flutterEngine.Run();
            GeneratedPluginRegistrant.RegisterWithRegistry(flutterEngine);

            var vc = new FlutterViewController(flutterEngine, null, null);
            PresentViewController(vc, true, null);
        }
    }
}
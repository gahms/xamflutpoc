using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Widget;
using IO.Flutter.Embedding.Android;
using Xamarin.Essentials;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace xamflutpoc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private const string FlutterFragmentTag = "flutter_fragment";

        private FlutterFragment flutterFragment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (_, __) => LaunchFlutterActivity();

            ShowFlutterFragment();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void LaunchFlutterActivity()
        {
            var intent = FlutterActivity.WithNewEngine().Build(this);
            StartActivity(intent);
        }

        private void ShowFlutterFragment()
        {
            /*var container = FindViewById<FrameLayout>(Resource.Id.fragment_container);

            flutterFragment = SupportFragmentManager
                .FindFragmentByTag(FlutterFragmentTag) as FlutterFragment;

            if (flutterFragment == null)
            {

            }*/
        }
    }
}

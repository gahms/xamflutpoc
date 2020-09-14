using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Google.Android.Material.FloatingActionButton;
using IO.Flutter.Embedding.Android;
using IO.Flutter.Embedding.Engine;
using IO.Flutter.Embedding.Engine.Dart;
using IO.Flutter.Plugins;
using Xamarin.Essentials;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace xamflutpoc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AndroidX.AppCompat.App.AppCompatActivity
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

        private void EnsureFlutterEngineCreated(string engineId)
        {
            if (!FlutterEngineCache.Instance.Contains(engineId))
            {
                var flutterEngine = new FlutterEngine(this);
                GeneratedPluginRegistrant.RegisterWith(flutterEngine);

                flutterEngine.DartExecutor.ExecuteDartEntrypoint(
                    DartExecutor.DartEntrypoint.CreateDefault()
                );

                FlutterEngineCache.Instance.Put(engineId, flutterEngine);
            }
        }

        private void LaunchFlutterActivity()
        {
            const string EngineId = "FlutterActivityEngine";
            EnsureFlutterEngineCreated(EngineId);

            var intent = FlutterActivity
                .WithCachedEngine(EngineId)
                .Build(this);

            StartActivity(intent);
        }

        private void ShowFlutterFragment()
        {
            flutterFragment = SupportFragmentManager
                .FindFragmentByTag(FlutterFragmentTag) as FlutterFragment;

            if (flutterFragment == null)
            {
                const string EngineId = "FlutterFragmentEngine";
                EnsureFlutterEngineCreated(EngineId);

                flutterFragment = FlutterFragment
                    .WithCachedEngine(EngineId)
                    .Build() as FlutterFragment;

                SupportFragmentManager
                    .BeginTransaction()
                    .Add(
                        Resource.Id.fragment_container,
                        flutterFragment,
                        FlutterFragmentTag
                    )
                    .Commit();
            }
        }
    }
}

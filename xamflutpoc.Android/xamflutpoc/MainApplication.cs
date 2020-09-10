using System;
using Android.App;
using Android.Runtime;
using IO.Flutter.Embedding.Engine;
using IO.Flutter.Embedding.Engine.Dart;
using IO.Flutter.Embedding.Engine.Plugins;
using IO.Flutter.Plugin.Common;
using IO.Flutter.Plugins;
using Java.Interop;
using Xamarin.Essentials;

namespace xamflutpoc
{
    [Application]
    public class MainApplication : Application
    {
        public const string FlutterEngineId = "MainFlutterEngine";

        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            Platform.Init(this);
            base.OnCreate();
        }
    }
}

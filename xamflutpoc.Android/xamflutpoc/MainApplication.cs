using System;
using Android.App;
using Android.Runtime;
using Xamarin.Essentials;

namespace xamflutpoc
{
    [Application]
    public class MainApplication : Application
    {
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

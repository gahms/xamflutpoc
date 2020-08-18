# Xamarin Flutter Proof of Concept
Make a Flutter view in a Xamarin app

## Flutter

```
$ cd my_flutter
$ flutter create --template module my_flutter
$ flutter build ios-framework --output=build/ios-flutter-framework
```

## Xamarin Bidings
```
$ cd xamflutpoc
$ sharpie bind -o FlutterBindings -sdk iphoneos13.6 -framework ../my_flutter/build/ios-flutter-framework/Debug/Flutter.framework
```

## References

https://github.com/flutter/flutter/issues/15200

https://flutter.dev/docs/development/add-to-app/ios/project-setup

https://docs.microsoft.com/en-us/xamarin/ios/platform/embedded-frameworks?tabs=macos

https://docs.microsoft.com/en-us/xamarin/ios/platform/binding-objective-c/walkthrough?tabs=macos#using-objective-sharpie

https://docs.microsoft.com/en-us/xamarin/cross-platform/macios/binding/objective-sharpie/examples/advanced
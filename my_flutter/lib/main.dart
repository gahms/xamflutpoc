import 'dart:io';

import 'package:device_info/device_info.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:package_info/package_info.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: MyHomePage(title: 'Flutter Demo Home Page'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  MyHomePage({Key key, this.title}) : super(key: key);

  final String title;

  @override
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  List<String> _texts = [];

  void _close() {
    SystemNavigator.pop();
  }

  @override
  void initState() {
    super.initState();
    _initStateInternal();
  }

  void _initStateInternal() async {
    // await Future.delayed(Duration(seconds: 5));

    final packageInfo = await PackageInfo.fromPlatform();
    final deviceInfo = DeviceInfoPlugin();

    final texts = [
      'packageInfo.appName: ${packageInfo.appName}',
      'packageInfo.packageName: ${packageInfo.packageName}',
      'packageInfo.buildNumber: ${packageInfo.buildNumber}',
    ];

    if (Platform.isAndroid) {
      final deviceInfoAndroid = await deviceInfo.androidInfo;

      texts.addAll([
        'deviceInfoAndroid.model: ${deviceInfoAndroid.model}',
        'deviceInfoAndroid.version: ${deviceInfoAndroid.version.sdkInt}',
      ]);
    } else {
      final deviceInfoiOS = await deviceInfo.iosInfo;

      texts.addAll([
        'deviceInfoiOS.model: ${deviceInfoiOS.model}',
        'deviceInfoiOS.systemVersion: ${deviceInfoiOS.systemVersion}',
      ]);
    }

    setState(() => _texts = texts);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: _texts.map((t) => Text(t)).toList(),
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: _close,
        tooltip: 'Close',
        child: Icon(Icons.close),
      ),
    );
  }
}

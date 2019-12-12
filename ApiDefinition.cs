using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace NativeLibrary
{
    [BaseType(typeof(NSObject))]
    interface UnityAppController : IUIApplicationDelegate
    {
        [Export("quitHandler", ArgumentSemantic.Copy)]
        Action QuitHandler { get; set; }

        [Export("rootView", ArgumentSemantic.Copy)]
        UIView RootView { get; }

        [Export("rootViewController", ArgumentSemantic.Copy)]
        UIViewController RootViewController { get; }
    }

    // NOTE:
    // We create a dummy I<DelegateName> here so we can reference it from the
    // delegate property and other members.
    interface IUnityFrameworkListener { }

    [BaseType(typeof(NSObject))]
    [Model]
    [Protocol]
    interface UnityFrameworkListener
    {
        [Export("unityDidUnload:")]
        void UnityDidUnload(NSNotification notification);

        [Export("unityDidQuit:")]
        void UnityDidQuit(NSNotification notification);
    }

    [BaseType(typeof(NSObject))]
    interface UnityFramework
    {
        [Export("appController")]
        UnityAppController AppController();

        [Static, Export("getInstance")]
        UnityFramework GetInstance();

        [Export("setDataBundleId:")]
        void SetDataBundleId([PlainString] string bundleId);

        [Internal, Export("runUIApplicationMainWithArgc:argv:")]
        void RunUIApplicationMainWithArgc(int argc, IntPtr argv);

        [Internal, Export("runEmbeddedWithArgc:argv:appLaunchOpts:")]
        void RunEmbeddedWithArgc(int argc, IntPtr argv, NSDictionary options);

        [Export("unloadApplication")]
        void UnloadApplication();

        [Export("quitApplication:")]
        void QuitApplication(int exitCode);

        // NOTE:
        // This method uses the dummy interface because it accepts a protocol
        // and not a concrete type.
        [Export("registerFrameworkListener:")]
        void RegisterFrameworkListener(IUnityFrameworkListener obj);

        // NOTE:
        // This method uses the dummy interface because it accepts a protocol
        // and not a concrete type.
        [Export("unregisterFrameworkListener:")]
        void UnregisterFrameworkListener(IUnityFrameworkListener obj);

        [Export("showUnityWindow")]
        void ShowUnityWindow();

        [Export("pause:")]
        void Pause(bool pause);

        [Export("setExecuteHeader:")]
        void SetExecuteHeader(ref MachHeader header);

        [Export("sendMessageToGOWithName:functionName:message:")]
        void SendMessageToGOWithName([PlainString] string goName, [PlainString] string functionName, [PlainString] string msg);
    }

}


#if UNITY_ANDROID

namespace MobileVersionCode
{
    public static partial class VersionCode
    {
        public static partial int GetVersionCode() 
        {
#if UNITY_EDITOR  
            return UnityEditor.PlayerSettings.Android.bundleVersionCode;
#else
            return UnityEditor.PlayerSettings.Android.bundleVersionCode;
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject packageManager = activity.Call<AndroidJavaObject>("getPackageManager");
            var pInfo = packageManager.Call<AndroidJavaObject>("getPackageInfo", Application.identifier, 0);
            return pInfo.Get<int>("versionCode");
#endif
        }
    }
}
#endif
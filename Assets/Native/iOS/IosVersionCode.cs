
#if UNITY_IOS
using System;

namespace MobileVersionCode
{
    public static partial class VersionCode
    {
#if !UNITY_EDITOR
        [System.Runtime.InteropServices.DllImport("__Internal")]
        private static extern int getBundleVersion();
#endif
        public static partial int GetVersionCode()
        {
#if !UNITY_EDITOR
            return getBundleVersion().ToString();
#else
            if (int.TryParse(UnityEditor.PlayerSettings.iOS.buildNumber, out var versionCode))
            {
                return versionCode;
            }
            
            throw new Exception("Failed to parse iOS build number");
#endif
        }
    }
}
#endif

using System;
using GamePushSDK.Ads;
using Godot;

namespace GamePushSDK
{
    public static class GPSdk
    {
        public static bool IsReady => IsReadyJS();
        public static event Action OnReady;

        public static readonly JSContext Context = new JSContext("window");

        private static bool _isInit = false;

        public static bool HasAvailable => OS.HasFeature("JavaScript");
        public static string Language => Context.GetString("GetLanguage");
        public static bool IsMobile => Context.GetBool("IsMobile");
        public static float ServerTime => Context.GetFloat("GetServerTime");
        
        public static void Init()
        {
            if (_isInit == true)
            {
                return;
            }
            
            Context.Call("OnInit", OnReadyCallback);
            
            GPPlayer.Init();
            GPGame.Init();
            GPAds.Init();
            GPPayments.Init();
            
            _isInit = true;
        }

        private static bool IsReadyJS()
        {
            return Context.GetBool("IsReady");
        }

        private static void OnReadyCallback()
        {
            OnReady?.Invoke();
        }
    }
}
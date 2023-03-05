using System;
using Godot;

namespace GamePushSDK.Ads
{
    public static class GPAds
    {
        public static FullscreenAds Fullscreen
        {
            get
            {
                if (_fullscreen == null)
                {
                    _fullscreen = new FullscreenAds(_context);
                }

                return _fullscreen;
            }
        }
        
        public static RewardedAds Rewarded
        {
            get
            {
                if (_rewarded == null)
                {
                    _rewarded = new RewardedAds(_context);
                }

                return _rewarded;
            }
        }

        private static FullscreenAds _fullscreen;
        private static RewardedAds _rewarded;

        private static JSContext _context => GPSdk.Context;

        public static bool IsAdblockEnabled => _context.GetBool("IsAdblockEnabled");

        public static event Action OnStart;
        public static event Action OnClose;
        
        public static void Init()
        {
        
            
            _context.Call("OnAdsStart", OnAdsStart);
            _context.Call("OnAdsClose", OnAdsClose);
            
            Fullscreen.Init();
            Rewarded.Init();
        }

        private static void OnAdsStart()
        {
            OnStart?.Invoke();
        }

        private static void OnAdsClose(object[] args)
        {
            OnClose?.Invoke();
        }
    }
}
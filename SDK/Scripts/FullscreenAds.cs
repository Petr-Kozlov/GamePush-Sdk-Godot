using System;

namespace GamePushSDK.Ads
{
    public class FullscreenAds
    {
        public event Action OnShow;
        public event Action OnClose;

        private readonly JSContext _context;

        private bool _isInit = false;

        public bool IsAvailable => IsAvailableAds();
        
        public FullscreenAds(JSContext context)
        {
            _context = context;
        }
        
        public void Show()
        {
            _context.Call("AdsShowFullscreen");
        }

        public void Init()
        {
            if (_isInit == true)
            {
                return;
            }
            
            _context.Call("OnAdsFullscreenStart", OnAdsFullscreenStartCallback);
            _context.Call("OnAdsFullscreenClose", OnAdsFullscreenCloseCallback);

            _isInit = true;
        }

        private void OnAdsFullscreenStartCallback()
        {
            OnShow?.Invoke();
        }

        private void OnAdsFullscreenCloseCallback(object[] args)
        {
            OnClose?.Invoke();
        }

        private bool IsAvailableAds()
        {
            return JSContext.IsAvailable && _context.GetBool("AdsFullscreenIsAvailable");
        }
    }
}
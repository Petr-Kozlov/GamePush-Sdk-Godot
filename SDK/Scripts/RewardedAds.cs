using System;

namespace GamePushSDK.Ads
{
    public class RewardedAds
    {
        public event Action OnShow;
        public event Action OnClose;
        public event Action OnRewarded;

        private readonly JSContext _context;

        private bool _isInit = false;
        
        public bool IsAvailable => IsAvailableAds();
        
        public RewardedAds(JSContext context)
        {
            _context = context;
        }
        
        public void Show()
        {
            _context.Call("AdsShowRewarded");
        }

        public void Init()
        {
            if (_isInit == true)
            {
                return;
            }
            
            _context.Call("OnAdsRewardedStart", OnAdsStart);
            _context.Call("OnAdsRewardedClose", OnAdsClose);
            _context.Call("OnAdsRewardedReward", OnAdsRewarded);

            _isInit = true;
        }

        private void OnAdsStart()
        {
            OnShow?.Invoke();
        }

        private void OnAdsClose(object[] args)
        {
            OnClose?.Invoke();
        }

        private void OnAdsRewarded()
        {
            OnRewarded?.Invoke();
        }
        
        private bool IsAvailableAds()
        {
            return JSContext.IsAvailable && _context.GetBool("AdsRewardedIsAvailable");
        }
    }
}
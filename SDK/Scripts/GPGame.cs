using System;

namespace GamePushSDK
{
    public static class GPGame
    {
        public static event Action OnPause;
        public static event Action OnResume;
        
        private static JSContext _context => GPSdk.Context;

        public static void Init()
        {
            _context.Call("OnGamePause", OnGamePause);
            _context.Call("OnGameResume", OnGameResume);
        }

        public static void GamePlayStart()
        {
            _context.Call("GamePlayStart");
        }

        public static void GamePlayStop()
        {
            _context.Call("GamePlayStop");
        }

        private static void OnGamePause()
        {
            OnPause?.Invoke();
        }

        private static void OnGameResume()
        {
            OnResume?.Invoke();
        }
    }
}
using System;
using Object = Godot.Object;

namespace GamePushSDK
{
    public static class GPPlayer
    {
        public static string ID => GetID();
        public static bool IsLoggedIn => _context.GetBool("IsLoggedIn");
        public static bool HasAnyCredentials => _context.GetBool("HasAnyCredentials");
        
        public static string Name
        {
            get => GetName();
            set => SetName(value);
        }
        public static string AvatarUrl
        {
            get => GetAvatarUrl();
            set => SetAvatarUrl(value);
        }

        public static event Action OnLoadSuccess;
        public static event Action OnLoadFailed;
        public static event Action<bool> OnLoad;
        
        public static event Action OnLoginSuccess;
        public static event Action OnLoginFailed;
        public static event Action<bool> OnLogin;
        
        public static event Action OnSyncSuccess;
        public static event Action OnSyncFailed;
        public static event Action<bool> OnSync;
        
        public static event Action OnFetchFieldsSuccess;
        public static event Action OnFetchFieldsFailed;
        public static event Action<bool> OnFetchFields;
        
        private static JSContext _context => GPSdk.Context;

        public static void Init()
        {
            _context.Call("OnPlayerSync", OnPlayerSync);
            _context.Call("OnPlayerLoad", OnPlayerLoad);
            _context.Call("OnPlayerLogin", OnPlayerLogin);
            _context.Call("OnPlayerFetchFields", OnPlayerFetchFields);
        }

        public static void Sync()
        {
            _context.Call("PlayerSync");
        }

        public static void Load()
        {
            _context.Call("PlayerLoad");
        }

        public static void Login()
        {
            if(IsLoggedIn == false)
            {
                _context.Call("PlayerLogin");
            }
        }

        public static void FetchFields()
        {
            _context.Call("PlayerFetchFields");
        }

        public static bool GetBool(string key, bool defaultValue = false)
        {
            object result = _context.Call("PlayerGet", key);
            
            if (bool.TryParse(result.ToString(), out bool value))
            {
                return value;
            }

            return defaultValue;
        }

        public static string GetString(string key)
        {
            object result = _context.Call("PlayerGet", key);

            return result.ToString();
        }

        public static void Set(string key, object value)
        {
            _context.Call("PlayerSet", key, value);
        }

        public static bool Has(string key)
        {
            return _context.GetBool("PlayerHas", key);
        }
        
        private static string GetID()
        {
            return _context.GetString("PlayerGetID");
        }

        private static string GetName()
        {
            return _context.GetString("PlayerGetName");
        }

        private static void SetName(string value)
        {
            _context.Call("PlayerSetName", value);
        }

        private static string GetAvatarUrl()
        {
            return _context.GetString("PlayerGetAvatar");
        }

        private static void SetAvatarUrl(string value)
        {
            _context.Call("PlayerSetAvatar", value);
        }
        
        private static void OnPlayerSync(object[] args)
        {
            if (bool.TryParse(args[0].ToString(), out bool success))
            {
                OnSync?.Invoke(success);

                if (success)
                {
                    OnSyncSuccess?.Invoke();
                    return;
                }
     
                OnSyncFailed?.Invoke();
            }
        }
        
        private static void OnPlayerLoad(object[] args)
        {
            if (bool.TryParse(args[0].ToString(), out bool success))
            {
                OnLoad?.Invoke(success);

                if (success)
                {
                    OnLoadSuccess?.Invoke();
                    return;
                }
     
                OnLoadFailed?.Invoke();
            }
        }
        
        private static void OnPlayerLogin(object[] args)
        {
            if (bool.TryParse(args[0].ToString(), out bool success))
            {
                OnLogin?.Invoke(success);

                if (success)
                {
                    OnLoginSuccess?.Invoke();
                    return;
                }
     
                OnLoginFailed?.Invoke();
            }
        }

        private static void OnPlayerFetchFields(object[] args)
        {
            if (bool.TryParse(args[0].ToString(), out bool success))
            {
                OnFetchFields?.Invoke(success);

                if (success)
                {
                    OnFetchFieldsSuccess?.Invoke();
                    return;
                }
     
                OnFetchFieldsFailed?.Invoke();
            }
        }
    }
}
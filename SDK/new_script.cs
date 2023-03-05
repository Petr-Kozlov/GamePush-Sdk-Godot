using System;
using Godot;
using GamePushSDK;
using GamePushSDK.Ads;

public class new_script : Node
{
    private bool _isReady;

    public override void _Ready()
    {
        GD.Print("hello editor");

        GPSdk.OnReady += Print;
        GPGame.OnPause += () => GD.Print("Game Pause");
        GPGame.OnResume += () => GD.Print("Game Resume");
        
        if (GPSdk.HasAvailable)
        {
            GPSdk.Init();
        }
    }

    private void Print()
    {
        GD.Print("Language: " + GPSdk.Language);
        GD.Print("Is Mobile: " + GPSdk.IsMobile);
        GD.Print("Player ID: " + GPPlayer.ID);
        GD.Print("Player Name: " + GPPlayer.Name);
        GD.Print("Player Avatar: " + GPPlayer.AvatarUrl);
        GD.Print("Player Is Logging: " + GPPlayer.IsLoggedIn);
        //GPAds.Fullscreen.Show();


        GPPlayer.OnLogin += OnLogin;
        GPPlayer.Login();

        GPPlayer.Sync();
        GD.Print(GPPlayer.GetString("Progress"));
        
        GPPlayer.Set("Progress", "new progress");
        GPPlayer.Sync();
        
        GD.Print(GPPlayer.GetString("Progress"));
    }

    private void OnLogin(bool success)
    {
        GD.Print("On Login: " + success);
    }
    
    public static class GPPayments
    {
        public static bool IsAvailable => _context.GetBool("PaymentsIsAvailable");

        private static JSContext _context => GPSdk.Context;

        public static event Action OnPurchase;
        public static event Action OnError;
        
        public static void Init()
        {
            _context.Call("OnPaymentsPurchase", OnPaymentsPurchase);
            _context.Call("OnPaymentsError", OnPaymentsError);
            _context.Call("OnPaymentsConsume", OnPaymentsConsume);
            _context.Call("OnPaymentsConsumeError", OnPaymentsConsumeError);
        }

        public static void Purchase(int id)
        {
            _context.Call("PaymentsPurchase", id);
        }

        public static void Consume(int id)
        {
            _context.Call("PaymentsConsume", id);
        }

        private static void OnPaymentsPurchase(object[] args)
        {
            
        }

        private static void OnPaymentsError(object[] args)
        {
            
        }

        private static void OnPaymentsConsume(object[] args)
        {
            
        }

        private static void OnPaymentsConsumeError(object[] args)
        {
            
        }
    }
}

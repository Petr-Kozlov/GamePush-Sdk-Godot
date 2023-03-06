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

        GPPayments.OnPurchase += OnPurchase;
        
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
        GPPayments.FetchProducts();
        
        
    }

    private void OnLogin(bool success)
    {
        GD.Print("On Login: " + success);
    }

    public override void _Input(InputEvent evt)
    {
        if (evt.IsActionPressed("ui_select"))
        {
            GPPayments.Purchase(1331);
            //GPPayments.Consume(1331);
            
            //GPPayments.Purchase(1332);
        }
    }

    private void OnPurchase(Product arg1, PlayerPurchases arg2)
    {
        if (arg2.productId == 1331)
        {
            GPPayments.Consume(1331);
        }
    }
}

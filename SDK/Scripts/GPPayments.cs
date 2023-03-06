using System;
using Newtonsoft.Json;

namespace GamePushSDK
{
    public static class GPPayments
    {
        public static bool IsAvailable => _context.GetBool("PaymentsIsAvailable");

        private static JSContext _context => GPSdk.Context;

        public static event Action<Product, PlayerPurchases> OnPurchase;
        public static event Action OnPurchaseError;
        public static event Action<Product, PlayerPurchases> OnConsume;
        public static event Action OnConsumeError;
        public static event Action<PaymentsFetchResult> OnFetchProducts;
        public static event Action OnFetchProductError;
        
        public static void Init()
        {
            _context.Call("OnPaymentsPurchase", OnPaymentsPurchase);
            _context.Call("OnPaymentsError", OnPaymentsError);
            _context.Call("OnPaymentsConsume", OnPaymentsConsume);
            _context.Call("OnPaymentsConsumeError", OnPaymentsConsumeError);
            _context.Call("OnPaymentsFetchProducts", OnPaymentsFetchProducts);
            _context.Call("OnPaymentsFetchErrorProducts", OnPaymentsFetchErrorProducts);
        }

        public static void Purchase(int id)
        {
            _context.Call("PaymentsPurchase", id);
        }

        public static void Consume(int id)
        {
            _context.Call("PaymentsConsume", id);
        }

        public static void FetchProducts()
        {
            _context.Call("PaymentsFetchProducts");
        }

        private static void OnPaymentsPurchase(object[] args)
        {
            Product product = JsonConvert.DeserializeObject<Product>(args[0].ToString());
            PlayerPurchases purchases = JsonConvert.DeserializeObject<PlayerPurchases>(args[1].ToString());
            
            OnPurchase?.Invoke(product, purchases);
        }

        private static void OnPaymentsError(object[] args)
        {
            OnPurchaseError?.Invoke();
        }

        private static void OnPaymentsConsume(object[] args)
        {
            Product product = JsonConvert.DeserializeObject<Product>(args[0].ToString());
            PlayerPurchases purchases = JsonConvert.DeserializeObject<PlayerPurchases>(args[1].ToString());
            
            OnConsume?.Invoke(product, purchases);
        }

        private static void OnPaymentsConsumeError(object[] args)
        {
            OnConsumeError?.Invoke();
        }
        
        private static void OnPaymentsFetchProducts(object[] args)
        {
            PaymentsFetchResult result = JsonConvert.DeserializeObject<PaymentsFetchResult>(args[0].ToString());
            
            OnFetchProducts?.Invoke(result);
        }

        private static void OnPaymentsFetchErrorProducts(object[] args)
        {
            OnFetchProductError?.Invoke();
        }
    }
    
    [System.Serializable]
    public struct Product
    {
        public int id;
        public string icon;
        public string iconSmall;
        public string tag;
        public string price;
        public bool isSubscription;
        public int period;
        public int trialPeriod;
        public string name;
        public string description;
        public string yandexId;
        public string currencySymbol;
        public string currency;

        public override string ToString()
        {
            string result = "Product: ";
            result += "ID: " + id + "\n"; 
            result += "Name: " + name + "\n"; 
            result += "Description: " + description + "\n"; 
            result += "Price: " + price + "\n"; 
            result += "Currency: " + currency + "\n"; 

            return result;
        }
    }

    [System.Serializable]
    public struct PlayerPurchases
    {
        public int productId;
        public Payload payload;
        public bool gift;
        public bool subscribed;
        
        public override string ToString()
        {
            string result = "Player Purchases: ";
            result += "ID: " + productId + "\n"; 
            result += "Payload: " + payload + "\n";
            result += "Subscribed: " + subscribed + "\n";
            result += "Gift: " + gift + "\n";

            return result;
        }
        
        [Serializable]
        public struct Payload
        {
            public string purchaseToken;
        }
    }



    [Serializable]
    public struct PaymentsFetchResult
    {
        public Product[] products;
        public Product[] playerPurchases;
    }
}
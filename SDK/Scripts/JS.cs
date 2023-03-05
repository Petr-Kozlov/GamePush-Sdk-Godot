using System;
using Godot;
using Object = Godot.Object;

namespace GamePushSDK
{
    public static class JS
    {
        public static JavaScriptObject Context
        {
            get
            {
                if (_context == null)
                {
                    _context = JavaScript.GetInterface("window");
                }

                return _context;
            }
        }

        private static JavaScriptObject _context;

        public static bool GetBool(string function)
        {
            string result = Context.Call(function).ToString();
            GD.Print("Get bool: " + result);

            //return result == "True" ||  result == "true";
            return bool.Parse(result);
        }
        
        public static string GetString(string function)
        {
            string result = Context.Call(function).ToString();
            GD.Print("Get string: " + result);

            return result;
        }
        
        public static int GetInt(string function)
        {
            string result = Context.Call(function).ToString();
            GD.Print("Get int: " + result);

            return int.Parse(result);
        }
        
        public static float GetFloat(string function)
        {
            string result = Context.Call(function).ToString();
            GD.Print("Get int: " + result);

            return float.Parse(result);
        }

        public static void Call(string function, Action callback)
        { 
            JsCallback callbackProvider = new JsCallback();
            callbackProvider.Function += callback;
            
            JavaScriptObject callbackObject =  JavaScript.CreateCallback(callbackProvider, nameof(callbackProvider.Invoke));

            Context.Call(function, callbackObject);
        }

        public static void Cell(string function, params object[] args)
        {
            Context.Call(function, args);
        }
    }

    public class JsCallback : Object
    {
        public event Action Function;
        public event Action<object[]> FunctionArgs;

        public void Invoke(params Object[] args)
        {
            Function?.Invoke();
            FunctionArgs?.Invoke(args);
        }
    }
}
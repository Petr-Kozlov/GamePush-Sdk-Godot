using System;
using Godot;

namespace GamePushSDK
{
    public class JSContext
    {
        public static bool IsAvailable => OS.HasFeature("JavaScript");

        private readonly JavaScriptObject _context;

        public JSContext(string context)
        {
            _context = JavaScript.GetInterface(context);
        }
        
        public bool GetBool(string function, params object[] args)
        {
            string result = _context.Call(function, args).ToString();
            GD.Print("Get bool: " + result);

            return bool.Parse(result);
        }
        
        public string GetString(string function, params object[] args)
        {
            string result = _context.Call(function, args).ToString();
            GD.Print("Get string: " + result);

            return result;
        }
        
        public int GetInt(string function,  params object[] args)
        {
            string result = _context.Call(function, args).ToString();
            GD.Print("Get int: " + result);

            return int.Parse(result);
        }
        
        public float GetFloat(string function,  params object[] args)
        {
            string result = _context.Call(function, args).ToString();
            GD.Print("Get int: " + result);

            return float.Parse(result);
        }

        public void Call(string function, Action callback)
        { 
            JsCallback callbackProvider = new JsCallback();
            callbackProvider.Function += callback;
            
            JavaScriptObject callbackObject =  JavaScript.CreateCallback(callbackProvider, nameof(callbackProvider.Invoke));

            _context.Call(function, callbackObject);
        }
        
        public void Call(string function, Action<object[]> callback)
        { 
            JsCallback callbackProvider = new JsCallback();
            callbackProvider.FunctionArgs += callback;
            
            JavaScriptObject callbackObject =  JavaScript.CreateCallback(callbackProvider, nameof(callbackProvider.Invoke));

            _context.Call(function, callbackObject);
        }

        public object Call(string function, params object[] args)
        {
            return _context.Call(function, args);
        }
        
    }
}
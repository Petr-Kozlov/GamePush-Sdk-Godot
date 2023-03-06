using System;
using Object = Godot.Object;

namespace GamePushSDK
{
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
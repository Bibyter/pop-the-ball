using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    [DefaultExecutionOrder(-1000)]
    public sealed class SimpleEventBus : MonoBehaviour
    {
        Dictionary<System.Type, System.Object> _events;

        private void Awake()
        {
            _events = new Dictionary<System.Type, object>(16);
        }

        public void Register<T>(System.Action<T> method) where T : struct
        {
            if (_events.TryGetValue(typeof(T), out var value))
            {
                _events[typeof(T)] = (value as System.Action<T>) + method;
            }
            else
            {
                _events.Add(typeof(T), new System.Action<T>(method));
            }
        }

        public void Unregister<T>(System.Action<T> method) where T : struct
        {
            if (_events.TryGetValue(typeof(T), out var value))
            {
                _events[typeof(T)] = (value as System.Action<T>) - method;
            }
        }

        public void Invoke<T>(T data) where T : struct
        {
            if (_events.TryGetValue(typeof(T), out var value))
            {
                (value as System.Action<T>)?.Invoke(data);
            }
        }
    }
}
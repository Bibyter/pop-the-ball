using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Client
{
    public struct ClickEvent
    {
        public string name;
    }


    public sealed class ClickAction : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] string _name;

        SimpleEventBus _eventBus;

        private void Awake()
        {
            _eventBus = FindObjectOfType<SimpleEventBus>();
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            _eventBus.Invoke(new ClickEvent() { name = _name });
        }
    }
}
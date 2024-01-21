using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;

namespace Lancy.UI
{
    [AddComponentMenu("UI/Empty Button", 30)]
    public class CButton :  MonoBehaviour, 
                            IPointerClickHandler, 
                            IPointerEnterHandler, 
                            IPointerExitHandler, 
                            IPointerDownHandler, 
                            IPointerUpHandler
    {
        [SerializeField] private UnityEvent clickEvent;

        [SerializeField] private UnityEvent enterEvent;
        [SerializeField] private UnityEvent exitEvent;

        [SerializeField] private UnityEvent upEvent;
        [SerializeField] private UnityEvent downEvent;


        public void OnPointerClick(PointerEventData eventData)
        {
            clickEvent.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            enterEvent.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            exitEvent.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            upEvent.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            downEvent.Invoke();
        }
    }
}
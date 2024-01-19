using UnityEngine;
using UnityEngine.Events;

public class CZoomButton : MonoBehaviour
{
    [SerializeField] private Transform transform;

    [Header("Scale Options")]
    [SerializeField] private Vector3 hoverScale = new Vector3(0.9f, 0.9f, 0.9f);
    [SerializeField] private Vector3 pressedScale = new Vector3(1.1f, 1.1f, 1.1f);
    [SerializeField] private Vector3 startScale = Vector3.one;

    [Header("Events")]
    [SerializeField] private UnityEvent enterEvents;
    [SerializeField] private UnityEvent clickEvents;

    private void Start()
    {
        if (transform == null)
        {
            transform = GetComponent<Transform>();
        }

        startScale = transform.localScale;
    }

    private void OnMouseEnter()
    {
        transform.localScale = hoverScale;
        enterEvents.Invoke();
    }

    private void OnMouseDown()
    {
        transform.localScale = pressedScale;
    }

    private void OnMouseExit()
    {
        transform.localScale = startScale;
    }

    private void OnMouseUpAsButton()
    {
        transform.localScale = startScale;
        clickEvents.Invoke();
    }
}

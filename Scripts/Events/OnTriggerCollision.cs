using System.Collections.Generic;
using UnityEngine;

public class OnTriggerCollision : MonoBehaviour
{
    [SerializeField] List<TagEvent> events = new List<TagEvent>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var e in events)
        {
            if (collision.gameObject.CompareTag(e.tagName))
            {
                e.unityEvents.Invoke();
            }
        }
    }
}
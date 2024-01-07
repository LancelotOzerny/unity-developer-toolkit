using System.Collections.Generic;
using UnityEngine;

public class OnColliderCollision : MonoBehaviour
{
    [SerializeField] List<TagEvent> events = new List<TagEvent>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var e in events)
        {
            if (e.tagName == collision.name)
            {
                e.unityEvents.Invoke();
            }
        }
    }
}

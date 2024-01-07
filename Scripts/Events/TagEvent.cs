using UnityEngine.Events;

[System.Serializable]
public class TagEvent
{
    public string tagName = string.Empty;
    public UnityEvent unityEvents = new UnityEvent();
}

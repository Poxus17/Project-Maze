using UnityEngine;

public class DetectableObject : MonoBehaviour, IDetectable
{
    [SerializeField] BoolEvent onDetectEvent;
    public void OnDetect(bool detected) { onDetectEvent.Invoke(detected); }
}

public interface IDetectable
{
    void OnDetect(bool detected);
}

using UnityEngine;

public class AnomalyComponent : MonoBehaviour
{
    [SerializeField] float maxHate = 100;
    [SerializeField] float hatePerSecond = 10;
    [SerializeField] float calmPerSecond = 5;
    [SerializeField] TriggerEventPacket hateCapEvent;

    private float hateMeter = 0;
    private bool isCalm = false;
    public void SetCalm(bool isCalm) => this.isCalm = isCalm;

    private void Update(){
        hateMeter += (isCalm ? -calmPerSecond : hatePerSecond) * Time.deltaTime;
        hateMeter = Mathf.Clamp(hateMeter, 0, maxHate);

        if(hateMeter >= maxHate)
            hateCapEvent.Invoke();
    }
}

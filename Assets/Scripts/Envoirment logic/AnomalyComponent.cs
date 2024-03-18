using UnityEngine;
using UnityEngine.Video;

public class AnomalyComponent : MonoBehaviour
{
    [SerializeField] float maxHate = 100;
    [SerializeField] float hatePerSecond = 10;
    [SerializeField] float calmPerSecond = 5;
    [SerializeField] bool reversed = false;
    [SerializeField] StringAnnouncerVariable flickerString;
    [SerializeField] TriggerEventPacket hateCapEvent;

    private float hateMeter = 0;
    private bool isCalm = false;
    public void SetCalm(bool isCalm) => this.isCalm = reversed ? !isCalm : isCalm;

    private void Update(){
        NormalHate();
        //Debug.Log(hateMeter);
    }

    private void NormalHate(){
        hateMeter += (isCalm ? -calmPerSecond : hatePerSecond) * Time.deltaTime;
        hateMeter = Mathf.Clamp(hateMeter, 0, maxHate);

        if(hateMeter >= maxHate)
            hateCapEvent.Invoke();
    }
}

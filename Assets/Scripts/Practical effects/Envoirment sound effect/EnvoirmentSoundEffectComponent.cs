using UnityEngine;
using UnityEngine.Events;

public class EnvoirmentSoundEffectComponent : MonoBehaviour
{
    [SerializeField, Tooltip("Max distance for detection")] float detectRange = 10;
    [SerializeField, Tooltip("How long needs to be detected for trigger")] float detectTime = 0.5f;
    [SerializeField, Tooltip("Will lock after trigger")] bool singleUse; // Does not account for reload
    [SerializeField] UnityEvent trigger;

    bool detected;
    bool wasDetected;
    bool triggered;

    float detectTimer = 0;

    public void Lose()
    {
        detected = false;
    }

    public bool Detect()
    {
        var distance = Vector3.Distance(gameObject.transform.position, CentralAI.Instance.player.transform.position);

        detected = (distance <= detectRange);
        return detected;
    }

    //This should probably be optimised right?
    private void Update()
    {
        if(detected)
        {
            wasDetected = detected;
            detectTimer += Time.deltaTime;

            if(detectTimer >= detectTime && !triggered)
            {
                triggered = true;
                trigger.Invoke();

                if(singleUse)
                {
                    tag = "Untagged";
                }
            }
        }
        else if (wasDetected)
        {
            wasDetected = false;
            triggered = false;
            detectTimer = 0f;
        }

    }
}

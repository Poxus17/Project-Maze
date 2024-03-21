using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FlickerHandler : MonoBehaviour
{
    [SerializeField] StringVariable flickerString;
    [SerializeField] float onTime;
    [SerializeField] float offTime;
    [SerializeField] float absoluteMinimum;
    private Light light;
    private bool flickerBlock => flickerString.value.Any(c => c != '0' && c != '1');

    private bool onGoingFlicker = false;
    private bool queuedFlicker = false;
    private int flickerIndex;

    private void Awake()
    {
        light = GetComponent<Light>();
    }

    public void Flicker(){
        if(flickerBlock)
            return;

        if(onGoingFlicker)
            queuedFlicker = true;

        onGoingFlicker = true;
        flickerIndex = 0;
        FlickerAction();
    }

    private void FlickerAction(){
        
        if(queuedFlicker)
        {
            queuedFlicker = false;
            return;
        }

        bool isOn = flickerString.value[flickerIndex] == '1';
        light.enabled = isOn;
        flickerIndex++;

        if(flickerIndex >= flickerString.value.Length)
        {
            onGoingFlicker = false;
            light.enabled = true;
            return;
        }

        GlobalTimerManager.instance.RegisterForTimer(FlickerAction, GetRandomFlicker(isOn ? onTime : offTime));
    }

    private IEnumerator FlickerCoroutine(){
        for(int i = 0; i < flickerString.value.Length; i++)
        {
            bool isOn = flickerString.value[i] == '1';
            light.enabled = isOn;
            yield return new WaitForSeconds(GetRandomFlicker(isOn ? onTime : offTime));
        }
    }

    public float GetRandomFlicker(float max)
    {
        return Random.Range(absoluteMinimum, max);
    }

    public void FlickerCheck(){
        //Checks to see if any characters exist aside from 1 and 0
        if(flickerBlock)
            Debug.Log("Illegal flicker");
        else
            Debug.Log("Flicker is legal");
            
    }
}

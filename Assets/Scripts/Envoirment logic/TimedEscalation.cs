using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Events;

public enum EscalationType
{
    Linear,
    Quadratic,
    InverseQuadratic,
    Exponential
    
}
public class TimedEscalation : MonoBehaviour
{
    [SerializeField] EscalationType escalationType;
    [SerializeField] float escalationTime;
    [SerializeField] bool escalateOnStart;
    [SerializeField] GameObject[] targets;
    [SerializeField] UnityEvent onEnd;

    private int escalationIndex = 0;
    private int targetsLength;
    private float deltaTime = 0;
    private float mod;

    private void Start(){
        targetsLength = targets.Length + 1;

        switch(escalationType){
            case EscalationType.Linear:
                mod = escalationTime / targetsLength;
                break;
            case EscalationType.Quadratic:
            case EscalationType.InverseQuadratic:
                mod = escalationTime / Mathf.Pow(targetsLength, 2);
                break;
            case EscalationType.Exponential:
                var y = escalationTime - 1;
                var x = 1/((float)targetsLength);
                mod = Mathf.Pow( y, x );
                break;
        }

        if(escalateOnStart)
            Escalate();
        else
            RegisterNextEscalation();
    }

    public void Escalate(){
        if(escalationIndex >= targetsLength)
        {
            gameObject.SetActive(false);
            onEnd.Invoke();
            return;
        }

        targets[Mathf.Clamp(escalationIndex - 1,0,100)].SetActive(true); //oh god kill me it's horrible
        RegisterNextEscalation();
    }

    private void RegisterNextEscalation(){
        
        float nextEscalateTime = 0;
        escalationIndex++;

        switch(escalationType){
            case EscalationType.Linear:
                nextEscalateTime = GetLinearTime();
                break;
            case EscalationType.Quadratic:
                nextEscalateTime = GetQuadraticTime();
                break;
            case EscalationType.InverseQuadratic:
            case EscalationType.Exponential:
                nextEscalateTime = GetExponentialTime();
                break;
        }

        deltaTime += nextEscalateTime;
        GlobalTimerManager.instance.RegisterForTimer(Escalate, nextEscalateTime);
    }

    private float GetLinearTime(){
        return (escalationIndex * mod) - deltaTime;
    }

    private float GetQuadraticTime(){
        var timeVal = Mathf.Pow(escalationIndex, 2) * mod;
        return timeVal - deltaTime;
    }

    private float GetInverseQuadraticTime(){
        var timeVal = Mathf.Pow(escalationIndex, 2) * mod;
        return timeVal - deltaTime;
    }

    private float GetExponentialTime(){
        var timeVal = Mathf.Pow(mod, escalationIndex) - 1;
        return timeVal - deltaTime;
    }

}

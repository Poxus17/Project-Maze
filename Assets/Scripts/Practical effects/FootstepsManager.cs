using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsManager : MonoBehaviour
{
    [SerializeField] AudioClip[] stepClips;
    [Space(10)]

    [Header("Walking Values")]
    [SerializeField] float walkStepTime;
    [SerializeField] float walkStepNoiseValue;
    [SerializeField] float walkVolume;

    [Space(10)]

    [Header("Running Values")]
    [SerializeField] float runStepTime;
    [SerializeField] float runStepNoiseValue;
    [SerializeField] float runVolume;

    [Space(10)]

    [Header("Sneaking Values")]
    [SerializeField] float sneakStepTime;
    [SerializeField] float sneakStepNoiseValue;
    [SerializeField] float sneakVolume;


    float stepTime = 0.8f;
    float stepNoiseValue = 3;
    float stepVolume; 

    bool activeStep = false;
    bool running = false;
    bool playingStep = false;
     // Start is called before the first frame update
    void Start()
    {
        FPSMovementController.OnChangeIsWalking += SetActiveStep;
        FPSMovementController.OnChangeMovementType += SetType;
    }

    void SetActiveStep(bool val)
    {
        var wasActive = activeStep;
        activeStep = val;

        if (activeStep && !wasActive && !playingStep)
        {
            InitStepsLoop();
        }
    }

    void SetType(MovementType type)
    {
        switch (type) 
        {
            case MovementType.Walk:
                stepTime = walkStepTime;
                stepNoiseValue = walkStepNoiseValue;
                NoiseManager.instance.SetPlaybackVolume(walkVolume);
                break;

            case MovementType.Run:
                stepTime = runStepTime;
                stepNoiseValue = runStepNoiseValue;
                NoiseManager.instance.SetPlaybackVolume(runVolume);
                break;

            case MovementType.Sneak:
                stepTime = sneakStepTime;
                stepNoiseValue = sneakStepNoiseValue;
                NoiseManager.instance.SetPlaybackVolume(sneakVolume);
                break;
        }
    }

    void InitStepsLoop(){
        playingStep = true;
        PlayStep();
        GlobalTimerManager.instance.RegisterForTimer(StepsLoop, stepTime);
    }

    void StepsLoop()
    {
        if(activeStep)
            GlobalTimerManager.instance.RegisterForTimer(StepsLoop, stepTime);
        else
        {
            playingStep = false;
            return;
        }

        PlayStep();
    }

    void PlayStep(){
        var selectClip = stepClips[Random.Range(0, stepClips.Length)];
        NoiseManager.instance.PlayNoise(selectClip, stepNoiseValue);
    }

    private void OnDestroy()
    {
        FPSMovementController.OnChangeIsWalking -= SetActiveStep;
        FPSMovementController.OnChangeMovementType -= SetType;
    }

}

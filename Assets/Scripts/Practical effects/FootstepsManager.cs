using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsManager : MonoBehaviour
{
    [SerializeField] float walkingStepTime;
    [SerializeField] float stepNoiseValue;
    [SerializeField] AudioClip[] stepClips;

    bool activeStep = false;
    bool running;

     // Start is called before the first frame update
    void Start()
    {
        FPSMovementController.OnChangeIsWalking += SetActiveStep;
    }

    void SetActiveStep(bool val)
    {
        var wasActive = activeStep;
        activeStep = val;

        if (activeStep && !wasActive)
        {
            StartCoroutine(StepsLoop());
        }
    }

    IEnumerator StepsLoop()
    {
        var selectClip = stepClips[Random.Range(0, stepClips.Length)];
        NoiseManager.instance.PlayNoise(selectClip, stepNoiseValue);

        yield return new WaitForSeconds(walkingStepTime * (running ? 2 : 1));

        if(activeStep)
            StartCoroutine(StepsLoop());
    }

}

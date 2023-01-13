using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhistleHandler : MonoBehaviour
{
    [SerializeField] AudioClip[] whistleClips;

    public void Whistle(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(context.started)
            NoiseManager.instance.PlayNoise(GetWhistle(), 200);
    }

    AudioClip GetWhistle()
    {
        var randomVal = Random.Range(0, whistleClips.Length - 1);
        var index = (int)Mathf.Round(randomVal);
        return whistleClips[index];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceThePlayer : MonoBehaviour
{
    [SerializeField] Vector3 faceOffset;
    [SerializeField] bool executeOnGameobjectActive;
    [SerializeField] bool executeConstantly;
    [SerializeField] bool useLerp;
    [SerializeField] float lerpSpeed;

    private void Start()
    {
        if (executeOnGameobjectActive)
        {
            //StandBehindPlayer();
            LookAtPlayer();
        }
            
    }

    private void Update()
    {
        if (!executeConstantly)
            return;
        
        if (useLerp)
            LerpLookAtPlayer();
        else
            LookAtPlayer();
    }

    public void LookAtPlayer()
    {
        var correctedPos = PlayerCameraHandler.instance.position;
        //correctedPos.y = transform.position.y;
        transform.rotation = Quaternion.LookRotation(correctedPos - transform.position) * Quaternion.Euler(faceOffset);
    }

    public void LerpLookAtPlayer()
    {
        var correctedPos = PlayerCameraHandler.instance.position;
        //correctedPos.y = transform.position.y;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(correctedPos - transform.position) * Quaternion.Euler(faceOffset), Time.deltaTime * lerpSpeed);
    }

    public void StandBehindPlayer()
    {
        transform.position = CentralAI.Instance.player.transform.position - CentralAI.Instance.player.transform.forward * 11;
    }
}

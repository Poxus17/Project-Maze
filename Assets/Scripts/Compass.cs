using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DEPRECATED
public class Compass : MonoBehaviour
{
    //Put this script on your needle object

    [SerializeField] float needleSpeed;
    [SerializeField] float idleSpinSpeed;
    [SerializeField] float rotationOffset;
   
    GameObject targetItem;
    bool idle;
    float needleRotationMod;

    private void Start()
    {
        SetIdle();
        needleRotationMod = 1 / needleSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(targetItem != null)
        {
            var eularAngles = transform.localEulerAngles;
            transform.LookAt(targetItem.transform);


            var eularPointing = transform.localEulerAngles;
            transform.eulerAngles = eularAngles;

            eularAngles.y = eularPointing.y + rotationOffset;

            var quaternionPointing = Quaternion.Euler(eularAngles);
            
            transform.localRotation = Quaternion.Slerp(transform.rotation, quaternionPointing, Time.deltaTime * needleSpeed);
        }

    }

    public void SwitchTarget()
    {
        if (SectionsManager.instance.currentSection == 0)
            SetIdle();
        else
        {
            targetItem = SectionsManager.instance.GetSectionItem();
            idle = false;
        }
        
    }

    public void SetIdle()
    {
        idle = true;
        //StartCoroutine(IdleAnimation());
    }

/*
    Deprecated IdleAnimation()
    {
        var eularAngles = transform.localEulerAngles;
        while (idle)
        {
            eularAngles.y += idleSpinSpeed * Time.deltaTime;
            transform.localEulerAngles = eularAngles;
            yield return null;
        }
    }
*/

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    GameObject targetItem;

    float x;
    private void Start()
    {
        x = transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetItem.transform);
        var eular = transform.localEulerAngles;
        eular.x = x;
        transform.localEulerAngles = eular;
    }

    public void SwitchTarget()
    {
        targetItem = SectionsManager.instance.GetSectionItem();
    }
}

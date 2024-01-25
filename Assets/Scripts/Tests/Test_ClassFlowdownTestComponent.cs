using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ClassFlowdownTestComponent : MonoBehaviour
{
    [SerializeField] int ID = 0;
    private FlowdownInfo flowdownInfo;
    public void SetFlowdownInfo(FlowdownInfo flowdownInfo){
        this.flowdownInfo = flowdownInfo;
    }

    public void SetFlowdownValue(float flowdownValue){
        flowdownInfo.SetFlowdownValue(flowdownValue);
        Debug.Log("Component " + ID + " setting flowdown value to " + flowdownValue);
    }
}

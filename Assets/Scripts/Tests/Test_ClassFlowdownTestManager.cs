using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Test_ClassFlowdownTestManager : MonoBehaviour
{
    private List<Test_ClassFlowdownTestComponent> testComponents;
    private FlowdownInfo flowdownInfo;
    private void Start(){
        testComponents = new List<Test_ClassFlowdownTestComponent>();
        testComponents = GetComponentsInChildren<Test_ClassFlowdownTestComponent>().ToList<Test_ClassFlowdownTestComponent>();

        flowdownInfo = new FlowdownInfo(0f);

        foreach(Test_ClassFlowdownTestComponent testComponent in testComponents){
            testComponent.SetFlowdownInfo(flowdownInfo);
        }
    }

    void Update(){
        Debug.Log("Manager reading flowdown value of " + flowdownInfo.FlowdownValue);
    }

}

public class FlowdownInfo{
    private float _flowdownValue;

    public float FlowdownValue => _flowdownValue;

    public FlowdownInfo(float flowdownValue){
        _flowdownValue = flowdownValue;
    }

    public void SetFlowdownValue(float flowdownValue){
        _flowdownValue = flowdownValue;
    }
}

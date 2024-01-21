using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Test_RealtimeNavigation : MonoBehaviour
{

    [SerializeField] float forwardTargetClearDistance = 30;
    [SerializeField] float wallDetectionThreshold = 5;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject marker;
    [SerializeField] GameObject targetMarker;

    public void FindRoute(){
        RaycastHit hit; 
        if(Physics.Raycast(transform.position, transform.forward, out hit, 100f, layerMask)){

            var dir = transform.forward;
            var checkpoint = hit.point - dir * 2.5f;
            marker.transform.position = checkpoint;
            Debug.DrawLine(transform.position, hit.point, Color.red, 5f);
            
            if(hit.distance > forwardTargetClearDistance)
                targetMarker.transform.position = transform.position + (transform.forward * forwardTargetClearDistance);
            else
                FindNewRoute(checkpoint);
        }
    }

    public void FindNewRoute(Vector3 checkpoint){

        RaycastHit hitRight;

        if(Physics.Raycast(checkpoint, transform.right, out hitRight, 100, layerMask)){
            marker.transform.position = checkpoint + transform.right * 2.5f;
            return;
        }
        

        RaycastHit hitLeft;
        bool findHitLeft = Physics.Raycast(checkpoint, -transform.right, out hitLeft, 20f, layerMask);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Test_RealtimeNavigation), true)]
public class Test_RealtimeNavigationEditor : Editor{
    public override void OnInspectorGUI(){
        DrawDefaultInspector();

        if(GUILayout.Button("Find Route")){
            var script = target as Test_RealtimeNavigation;
            script.FindRoute();
        }
    }
}

#endif

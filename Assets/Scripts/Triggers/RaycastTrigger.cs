using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTrigger : BaseTrigger
{
    [Space(10), Header("Raycast Settings"), Space(5)]
    [SerializeField] Transform origin; //origin of raycast.
    [SerializeField] Transform target; //target of raycast.
    [SerializeField] LayerMask layerMask; //layermask to raycast against.
    [SerializeField] float sightRange; //range of raycast.
    [SerializeField] float minAngleFromOriginForward = 0f; //minimum angle from origin forward to target.
    [SerializeField] float maxAngleFromOriginForward = 360f; //maximum angle from origin forward to target.

    private float minCosAngle;
    private float maxCosAngle;

    private void Start(){
        minCosAngle = Mathf.Cos(minAngleFromOriginForward * Mathf.Deg2Rad);
        maxCosAngle = Mathf.Cos(maxAngleFromOriginForward * Mathf.Deg2Rad);
    }

    private void Update(){

        if(!active) return;

        var dot = Vector3.Dot(Vector3.Normalize(target.position - origin.position), Vector3.Normalize(origin.forward));
        Debug.DrawRay(origin.position, target.position - origin.position, Color.red);
        Debug.Log(dot);
        if(dot > minCosAngle || dot < maxCosAngle) return;

        RaycastHit hit;
        if(Physics.Raycast(origin.position, target.position - origin.position, out hit, sightRange, layerMask)){
            if(hit.collider.gameObject == target.gameObject){
                Trigger();
            }
        }
    }
}

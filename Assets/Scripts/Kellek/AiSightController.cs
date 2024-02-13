using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif // UNITY_EDITOR

public class AiSightController : MonoBehaviour
{
    [SerializeField] public float sightRange;
    [SerializeField] public float angleFromForward;
    [SerializeField] LayerMask layerMask;
    [SerializeField] FloatVariable playerDistanceSqr;
    [SerializeField] Vector3Variable targetVector;

    //Remove this from here
    /*[SerializeField] float jumpscareDistance;
    [SerializeField] GameEvent initJumpscare;*/

    float cosAngle;

    public delegate void SeeTarget();
    public static event SeeTarget OnSeeTarget;

    private void Start()
    {
        cosAngle = Mathf.Cos(angleFromForward * Mathf.Deg2Rad);
        Debug.Log("Kellek sight cos angle - " + cosAngle);
    }

    private void Update()
    {
        if (playerDistanceSqr.value > sightRange * sightRange)
            return;

        var normilizedDotProduct = Vector3.Dot(targetVector.value.normalized, transform.forward.normalized);
        
        if (normilizedDotProduct < cosAngle)
            return;

        var toPlayer = CentralAI.Instance.player.transform.position - transform.position;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, toPlayer, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                OnSeeTarget();
            }
            else
            {
                Debug.Log("Kellek sight hit - " + hit.collider.gameObject.tag);
            }
        }
        Debug.DrawRay(transform.position, toPlayer, Color.red);
    }

    public bool CustomPlayerCheck(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, targetVector.value, out hit, Mathf.Infinity, layerMask))
            return hit.collider.gameObject.tag == "Player";

        return false;
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(AiSightController))]
public class EnemySightAIEditor : Editor
{
    public void OnSceneGUI()
    {
        var ai = target as AiSightController;

        // work out the start point of the vision cone
        Vector3 startPoint = Mathf.Cos(-ai.angleFromForward * Mathf.Deg2Rad) * ai.transform.forward +
                             Mathf.Sin(-ai.angleFromForward * Mathf.Deg2Rad) * ai.transform.right;

        // draw the vision cone
        Handles.color = new Color(1,0,0,0.2f);
        Handles.DrawSolidArc(ai.transform.position, Vector3.up, startPoint, ai.angleFromForward * 2f, ai.sightRange);
    }
}
#endif // UNITY_EDITOR
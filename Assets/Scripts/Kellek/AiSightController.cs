using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif // UNITY_EDITOR

public class AiSightController : MonoBehaviour
{
    [SerializeField] float sightRange;
    [SerializeField] public float angleFromForward;
    [SerializeField] GameObject player;

    float cosAngle;

    private void Start()
    {
        cosAngle = Mathf.Cos(angleFromForward * Mathf.Deg2Rad);
    }

    private void Update()
    {
        var targetVector = player.transform.position - transform.position;

        if (targetVector.sqrMagnitude > sightRange * sightRange)
            return;

        if (Vector3.Dot(targetVector, -transform.forward) > cosAngle)
            return;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, targetVector, out hit))
        {
            if(hit.collider.gameObject == player)
                Debug.Log("In sight");
        }
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(AiSightController))]
public class EnemyAIEditor : Editor
{
    public void OnSceneGUI()
    {
        var ai = target as AiSightController;

        // work out the start point of the vision cone
        Vector3 startPoint = Mathf.Cos(-ai.angleFromForward * Mathf.Deg2Rad) * ai.transform.forward +
                             Mathf.Sin(-ai.angleFromForward * Mathf.Deg2Rad) * ai.transform.right;

        // draw the vision cone
        Handles.color = new Color(1,0,0,0.2f);
        Handles.DrawSolidArc(ai.transform.position, Vector3.up, startPoint, ai.angleFromForward * 2f, ai.angleFromForward);
    }
}
#endif // UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AiMovementController : MonoBehaviour
{
    NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 toPosition)
    {
        agent.SetDestination(toPosition);
    }

    public void SetSpeed(float newSpeed)
    {
        agent.speed = newSpeed;
    }
}

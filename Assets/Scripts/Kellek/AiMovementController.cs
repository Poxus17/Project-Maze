using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AiMovementController : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    NavMeshAgent agent;

    bool waitinForDestination = false;
    public delegate void ArrivedAtDestination();
    public static event ArrivedAtDestination OnArrivedAtDestination;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 toPosition)
    {
        agent.SetDestination(toPosition);

        if(!waitinForDestination)
            StartCoroutine(DestinationArrivalCheck());
    }

    public void SetSpeed(float newSpeed)
    {
        agent.speed = newSpeed;
    }

    public void CancelMovement()
    {
        agent.isStopped = true;
    }

    IEnumerator DestinationArrivalCheck()
    {
        waitinForDestination = true;

        bool stillMoving = true;
        float dist;
        yield return null;

        while (stillMoving)
        {
            dist = agent.remainingDistance;
            stillMoving = !(dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0);
            yield return null;
        }

        waitinForDestination = false;

        OnArrivedAtDestination();
    }

    public void SwitchToPlayer()
    {
        MoveTo(CentralAI.Instance.player.transform.position);
    }

    public void SetChaseSpeed(bool isChase)
    {
        agent.speed = isChase ? runSpeed : walkSpeed;
    }
}

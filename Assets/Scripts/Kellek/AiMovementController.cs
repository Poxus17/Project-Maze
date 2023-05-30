using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMovementController : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] FloatVariable timeSinceLastSteeringTarget;

    bool waitinForDestination = false;
    public delegate void ArrivedAtDestination();
    public static event ArrivedAtDestination OnArrivedAtDestination;

    //Debuging shit
    Vector3 lastSteeringTarget;
    float timeSinceLastTarget = 0;
    private void Start()
    {
        lastSteeringTarget = Vector3.zero;
    }

    private void Update()
    {
        //might add checking range here

        if(lastSteeringTarget != agent.steeringTarget)
        {
            lastSteeringTarget = agent.steeringTarget;
            timeSinceLastTarget = 0;
        }
        timeSinceLastTarget += Time.deltaTime;

        timeSinceLastSteeringTarget.value = timeSinceLastTarget;
    }

    public void MoveTo(Vector3 toPosition)
    {
        SetStop(false);
        agent.SetDestination(toPosition);
        //Debug.Log("Move to " + toPosition);
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
            stillMoving = !(dist != Mathf.Infinity && dist <= 2f);
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

    public void Teleport(Vector3 pos)
    {
        agent.Warp(pos);
    }

    public void SetStop(bool setTo)
    {
        if(agent.isOnNavMesh)
            agent.isStopped = setTo;
    }

    public static void Debug_PrintListeners()
    {
        Debug.Log(OnArrivedAtDestination.GetInvocationList().Length);
    }
}

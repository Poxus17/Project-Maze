using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Profiling;

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

    Vector3 savedPos;

    private void Start()
    {
        lastSteeringTarget = Vector3.zero;
        agent.speed = walkSpeed;
        savedPos = transform.position;
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
        Debug.Log("Kellek move to " + toPosition);
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
        Profiler.BeginSample("AIMovement.DestinationArrivalCheck()");
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
        Profiler.EndSample();
    }

    public bool SwitchToPlayer()
    {
        if(!agent.CalculatePath(CentralAI.Instance.player.transform.position, new NavMeshPath()))
            return false;

        MoveTo(CentralAI.Instance.player.transform.position);
        return true;
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

    public void SavePosition()
    {
        savedPos = agent.gameObject.transform.position;
    }

    public void RestorePosition()
    {
        Teleport(savedPos);
    }

    public static void Debug_PrintListeners()
    {
        Debug.Log(OnArrivedAtDestination.GetInvocationList().Length);
    }
}

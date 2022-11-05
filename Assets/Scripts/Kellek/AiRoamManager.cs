using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRoamManager : MonoBehaviour
{
    //RoamPointData[] roamPoints;
    List<RoamPointData> roamPoints;

    RoamPointData[] loadedRoampoints;
    // Start is called before the first frame update
    void Start()
    {
        roamPoints = new List<RoamPointData>();
        loadedRoampoints = new RoamPointData[0];

        var roamPointObjects = GameObject.FindGameObjectsWithTag("RoamPoint");

        foreach(var roamPoint in roamPointObjects)
        {
            RoamPointData roamData = roamPoint.GetComponent<RoamPointData>();

            if(roamData != null)
                roamPoints.Add(roamData);
        }
    }

    public Vector3 GetRoamPoint(Vector3 lastRoamPosition)
    {
        //ADD ZONE AND RING CHECKS
        //VERY CRUTIAL NO PRESSURE

        int randomIndex;
        Vector3 roamPosition;
        do
        {
            randomIndex = Random.Range(0, roamPoints.Count);
            roamPosition = roamPoints[randomIndex].transform.position;
        }
        while (roamPosition == lastRoamPosition);

        return roamPosition;
    }

    public Vector3 FindFarthestPoint()
    {
        float max = -100;
        Vector3 maxPoint = Vector3.zero;

        foreach(RoamPointData roamPoint in roamPoints)
        {
            var playerPointDistance = Vector3.Distance(CentralAI.Instance.player.transform.position, roamPoint.transform.position);
            if ( playerPointDistance > max)
            {
                max = playerPointDistance;
                maxPoint = roamPoint.transform.position;
            }
        }

        return maxPoint;
    }

    public void LoadRoamData(int ring, int section)
    {
       List<RoamPointData> localRoamPoints = new List<RoamPointData>();

        foreach(RoamPointData rpd in roamPoints)
        {
            if(rpd.ring == ring && rpd.zone == section)
                localRoamPoints.Add(rpd);
        }

        loadedRoampoints = localRoamPoints.ToArray();
    }

    /*public void LoadRoamPoints(RoamPointData[] roamPointArray)
    {
        roamPoints = roamPointArray;
    }*/
}

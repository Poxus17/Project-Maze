using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRoamManager : MonoBehaviour
{
    //RoamPointData[] roamPoints;
    List<RoamPointData> roamPoints;
    // Start is called before the first frame update
    void Start()
    {
        roamPoints = new List<RoamPointData>();


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

    /*public void LoadRoamPoints(RoamPointData[] roamPointArray)
    {
        roamPoints = roamPointArray;
    }*/
}

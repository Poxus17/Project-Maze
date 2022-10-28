using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionComponent : MonoBehaviour
{
    [SerializeField, Range(1,4)] int sectionNumber;
    [SerializeField, Range(1,3)] int ringNumber;
    [SerializeField] float spawnTime;
    [SerializeField] RoamPointData[] roamPointdData;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if(SectionsManager.instance.EnterSection(sectionNumber, ringNumber))
            {

            }
        }
    }
}

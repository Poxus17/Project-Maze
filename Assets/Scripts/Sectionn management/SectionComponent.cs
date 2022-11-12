using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionComponent : MonoBehaviour
{
    [SerializeField, Range(1,4)] int sectionNumber;
    [SerializeField, Range(1,3)] int ringNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && SectionsManager.instance.currentSection != sectionNumber)
        {
            Debug.Log(other.gameObject.name + " has entered section " + sectionNumber);
            SectionsManager.instance.EnterSection(sectionNumber);
        }
    }
}

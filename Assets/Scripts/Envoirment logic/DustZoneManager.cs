using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustZoneManager : MonoBehaviour
{
    [SerializeField] float activationRange = 45.0f;
    public GameObject zoneParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            zoneParticles.SetActive(true);

            // Find all the volume GameObjects in the scene
            DustZoneManager[] volumes = FindObjectsOfType<DustZoneManager>();

            // Iterate through the volumes and activate the ones within range of the player
            foreach (DustZoneManager volume in volumes)
            {
                float distance = Vector3.Distance(volume.transform.position, transform.position);

                volume.zoneParticles.SetActive(distance <= activationRange);
            }
        }
    }

}

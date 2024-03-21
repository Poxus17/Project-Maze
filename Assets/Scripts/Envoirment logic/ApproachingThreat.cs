using UnityEngine;
using System.Linq;

public class ApproachingThreat : MonoBehaviour
{
    [SerializeField] GameObject threatObject;
    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;
    
    private Vector3[] spawnPositions;


    private void Awake(){
        var children = GetComponentsInChildren<Transform>();
        spawnPositions = children.Where(x => x.tag.Contains("RoamPoint")).Select(x => x.position).ToArray();
    }

    private void SpawnAtRandomPosition()
    {
        int randomIndex;
        Vector3 heading;
        float dot;

        do{
        randomIndex = Random.Range(0, spawnPositions.Length);
        heading = spawnPositions[randomIndex] - PlayerCameraHandler.instance.position;
        dot = Vector3.Dot(heading, PlayerCameraHandler.instance.transform.forward);
        }
        while(dot >= 0);


        threatObject.transform.position = spawnPositions[randomIndex];
        threatObject.transform.rotation = FaceThePlayer.GetFaceThePlayerRotation(threatObject.transform.position, new Vector3(0,180,0));
        threatObject.SetActive(true);
    }

    public void Detected(bool detected)
    {
        if (detected){
            threatObject.SetActive(false);
            var randomTime = Random.Range(minSpawnTime, maxSpawnTime);
            GlobalTimerManager.instance.RegisterForTimer(SpawnAtRandomPosition, randomTime);
        }   
    }


}

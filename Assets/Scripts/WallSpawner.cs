using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class WallSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;
    public float length = 10.0f;
    public float minScale = 1.0f;
    public float maxScale = 2.0f;
    public Vector3 rotationEuler = Vector3.zero;
    public bool randomRotation;
    public float minDistance = 1f;
    public float maxDistance = 2f;
    

    [HideInInspector] public GameObject lastSpawnedParent;

    public void SpawnAlongWall()
    {
        if (prefabsToSpawn.Length == 0) return;

        GameObject newSpawnedParent = new GameObject("SpawnDaddy" + Random.Range(0, 10000).ToString());

        float coveredDistance = 0;

        while (coveredDistance < length)
        {
            GameObject prefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];
            GameObject spawnedObj = PrefabUtility.InstantiatePrefab(prefab) as GameObject;

            if (spawnedObj)
            {
                spawnedObj.transform.position = transform.position + transform.forward * coveredDistance;

                spawnedObj.transform.rotation = Quaternion.Euler(rotationEuler);

                if(randomRotation)
                    spawnedObj.transform.rotation = Quaternion.Euler(rotationEuler.x, Random.Range(0, 360), rotationEuler.z);

                float randomScaleValue = Random.Range(minScale, maxScale);
                spawnedObj.transform.localScale = new Vector3(randomScaleValue, randomScaleValue, randomScaleValue);

                spawnedObj.transform.SetParent(newSpawnedParent.transform);
            }

            coveredDistance += Random.Range(minDistance, maxDistance);
        }

        lastSpawnedParent = newSpawnedParent;
    }
}

[CustomEditor(typeof(WallSpawner))]
public class WallSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WallSpawner spawner = (WallSpawner)target;

        if (GUILayout.Button("Spawn"))
        {
            spawner.SpawnAlongWall();
        }

        if (GUILayout.Button("Undo Last Spawn"))
        {
            if (spawner.lastSpawnedParent)
            {
                DestroyImmediate(spawner.lastSpawnedParent);
                spawner.lastSpawnedParent = null;
            }
        }
    }
}
#endif

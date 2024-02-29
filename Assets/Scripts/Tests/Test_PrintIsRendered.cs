using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Test_PrintIsRendered : MonoBehaviour
{
    MeshRenderer meshRenderer; //Mesh renderer

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(meshRenderer.isVisible)
            Debug.Log("Object + " + gameObject.name + " is visible");
    }
}

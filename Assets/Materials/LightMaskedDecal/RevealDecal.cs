using UnityEngine;

[ExecuteInEditMode]
public class RevealDecal : MonoBehaviour
{
    [SerializeField] Material DecalMaterial;
    [SerializeField] Light MyLight;
	
	void Update ()
    {
        if(DecalMaterial == null)
            return;

        if (MyLight.type == LightType.Spot)
        {
            DecalMaterial.SetVector("_MyLightPosition", (MyLight.transform.position));
            DecalMaterial.SetVector("_MyLightDirection", -MyLight.transform.forward);
            DecalMaterial.SetFloat("_MyLightAngle", MyLight.spotAngle);
            DecalMaterial.SetFloat("_LightType", 0);
        }
        else if(MyLight.type == LightType.Point)
        {
            DecalMaterial.SetVector("_MyLightPosition", (MyLight.transform.position));            
            DecalMaterial.SetFloat("_MyLightRange", MyLight.range);
            DecalMaterial.SetFloat("_LightType", 1);
        }
    }
}
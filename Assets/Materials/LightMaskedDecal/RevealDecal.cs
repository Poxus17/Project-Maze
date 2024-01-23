//Shady
using UnityEngine;

[ExecuteInEditMode]
public class RevealDecal : MonoBehaviour
{
    [SerializeField] Material Mat;
    [SerializeField] Light SpotLight;
	
	void Update ()
    {
        if(Mat == null)
            return;

        Mat.SetVector("_MyLightPosition",  (SpotLight.transform.position));
        Mat.SetVector("_MyLightDirection", -SpotLight.transform.forward );
        Mat.SetFloat ("_MyLightAngle", SpotLight.spotAngle         );
    }//Update() end
}//class end
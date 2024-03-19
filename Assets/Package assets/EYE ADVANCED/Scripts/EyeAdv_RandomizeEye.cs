using UnityEngine;

public class EyeAdv_RandomizeEye : MonoBehaviour
{
    [SerializeField] Texture2D[] irisTextures;
    private Renderer eyeRenderer;

    // Start is called before the first frame update

    private void OnEnable(){
        eyeRenderer = gameObject.GetComponent<Renderer>();
        eyeRenderer.material.SetTexture("_IrisColorTex", irisTextures[Random.Range(0, irisTextures.Length)]);
    }

}

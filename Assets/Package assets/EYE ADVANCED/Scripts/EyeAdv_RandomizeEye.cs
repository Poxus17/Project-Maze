using UnityEngine;

public class EyeAdv_RandomizeEye : MonoBehaviour
{
    [SerializeField] Texture2D[] irisTextures;
    private Renderer eyeRenderer;

    // Start is called before the first frame update
    void Start()
    {
        eyeRenderer = gameObject.GetComponent<Renderer>();
        eyeRenderer.sharedMaterial.SetTexture("_IrisColorTex", irisTextures[Random.Range(0, irisTextures.Length)]);
    }
}

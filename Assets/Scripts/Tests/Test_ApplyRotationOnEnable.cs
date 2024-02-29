using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class Test_ApplyRotationOnEnable : MonoBehaviour
{
    [SerializeField] FloatVariable rotation;

    private RectTransform rectTransform;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable(){
        rectTransform.rotation = Quaternion.Euler(0, 0, -rotation.value);
    }
}

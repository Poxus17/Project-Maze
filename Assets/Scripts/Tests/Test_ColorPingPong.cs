using UnityEngine;
using UnityEngine.UI;

public class Test_ColorPingPong : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Color color1;
    [SerializeField] Color color2;

    private void Update(){
        image.color = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, 1));
    }
}

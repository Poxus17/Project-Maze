using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Test_Jumpscare : MonoBehaviour
{
    [SerializeField] float jumpscareTime = 0f;

    private float timer = 0f;
    private RectTransform rectTransform;

    void Start(){
        rectTransform = GetComponent<RectTransform>();
    }

    void Update(){
        if(timer >= jumpscareTime){
            gameObject.SetActive(false);
        }

        var scale = Mathf.Lerp(0f, 1f, timer / jumpscareTime);
        rectTransform.localScale = new Vector3(scale, scale, 1f);

        timer += Time.deltaTime;
    }
}

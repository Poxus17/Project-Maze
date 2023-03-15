using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMovement : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] float delay;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < delay)
            timer += Time.deltaTime;
        else
            transform.position += direction * speed * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float speed = 0.1f;
    [SerializeField] float delta = 1.0f;

    [Space(5)]
    [Header("Random delay")]
    [SerializeField] float minDelay;
    [SerializeField] float maxDelay;


    private float startY;
    private float length;

    private void Start()
    {
        startY = transform.position.y;
        length = delta * 2;

        StartCoroutine(Floating());
    }

    IEnumerator Floating()
    {
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

        while (true)
        {
            float newY = startY + delta * Mathf.Sin(speed * Time.time);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}

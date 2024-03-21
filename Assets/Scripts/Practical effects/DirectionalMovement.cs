using UnityEngine;

public class DirectionalMovement : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;


    // Update is called once per frame
    void Update()
    {
        var localDirection = transform.TransformDirection(direction);
        transform.position += localDirection * speed * Time.deltaTime;
    }
}

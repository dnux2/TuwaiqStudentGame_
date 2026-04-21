using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speed = 5f;
    private bool move = false;

    void Update()
    {
        if (move)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            move = true;
        }
    }

}
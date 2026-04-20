using UnityEngine;

public class CamelMove : MonoBehaviour
{
    public float speed = 5f;
    public bool move = false;

    void Update()
    {
        if (move)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    public void StartMoving()
    {
        move = true;
    }
}
using UnityEngine;

public class TreeEnemy : MonoBehaviour
{
    public float moveDistance = 2f;
    public float speed = 6f;
    public float waitTime = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool isMoving = false;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.right * moveDistance;

        InvokeRepeating(nameof(TriggerMove), waitTime, waitTime);
    }

    void TriggerMove()
    {
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                speed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                transform.position = startPos;
                isMoving = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Dead");
        }
    }
}
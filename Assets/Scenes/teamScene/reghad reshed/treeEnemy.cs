using UnityEngine;
using System.Collections;

public class TreeEnemy : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 2f;

    public float attackForce = 20f;
    public float returnSpeed = 3f;
    public float waitTime = 1.5f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool goingRight = true;

    private Rigidbody rb;
    private bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        targetPos = startPos + Vector3.right * moveDistance;
    }

    void Update()
    {
        if (!isAttacking)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                if (goingRight)
                    targetPos = startPos - Vector3.right * moveDistance;
                else
                    targetPos = startPos + Vector3.right * moveDistance;

                goingRight = !goingRight;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isAttacking)
        {
            StartCoroutine(Attack(other.transform));
        }
    }

    IEnumerator Attack(Transform player)
    {
        isAttacking = true;

        Vector3 direction = (player.position - transform.position).normalized;
        rb.AddForce(direction * attackForce, ForceMode.Impulse);

        yield return new WaitForSeconds(waitTime);

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        while (Vector3.Distance(transform.position, startPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                startPos,
                returnSpeed * Time.deltaTime
            );
            yield return null;
        }

        rb.isKinematic = false;
        isAttacking = false;
    }
}
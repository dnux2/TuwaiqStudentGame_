using UnityEngine;
using System.Collections;

public class TreeTrap : MonoBehaviour
{
    public float upSpeed = 20f;
    public float delayBeforeFall = 0.2f;

    private Rigidbody rb;
    private bool isActivated = false;
    private Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;

        rb.constraints = RigidbodyConstraints.FreezePositionX |
                         RigidbodyConstraints.FreezePositionZ |
                         RigidbodyConstraints.FreezeRotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            StartCoroutine(TrapRoutine());
        }
    }

    IEnumerator TrapRoutine()
    {
        // Move up fast
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.linearVelocity = Vector3.up * upSpeed;

        yield return new WaitForSeconds(delayBeforeFall);

        // Fall down
        rb.useGravity = true;

        // Wait until back near start position
        yield return new WaitUntil(() =>
            Mathf.Abs(transform.position.y - startPos.y) < 0.1f);

        rb.linearVelocity = Vector3.zero;
        transform.position = startPos;

        isActivated = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
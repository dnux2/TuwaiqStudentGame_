using UnityEngine;

public class PalmCollider : MonoBehaviour
{
    public float attackForce = 20f;
    private Rigidbody rb;
    private bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isAttacking)
        {
            isAttacking = true;

            Vector3 direction = (other.transform.position - transform.position).normalized;
            rb.AddForce(direction * attackForce, ForceMode.Impulse);
        }
    }
}
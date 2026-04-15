using UnityEngine;

public class TreeEnemy : MonoBehaviour
{
    public float attackForce = 20f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            rb.AddForce(direction * attackForce, ForceMode.Impulse);
        }
    }
}
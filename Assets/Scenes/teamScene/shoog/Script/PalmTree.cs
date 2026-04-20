using UnityEngine;
using System.Collections;

public class PalmTree : MonoBehaviour
{
    public GameObject datePrefab;
    public Transform throwPoint;
    public float throwForce = 15f;
    public float detectionRange = 40f;
    public int dateCount = 5;
    public float spawnDelay = 0.3f; // التأخير بين كل تمرة

    private Transform player;
    private bool hasThrown = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distToPlayer = Vector3.Distance(transform.position, player.position);

        if (distToPlayer < detectionRange && !hasThrown)
        {
            StartCoroutine(SpawnDate());
            hasThrown = true;
        }
    }

    IEnumerator SpawnDate()
    {
        for (int i = 0; i < dateCount; i++)
        {
            ThrowDate();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void ThrowDate()
    {
        GameObject date = Instantiate(datePrefab, throwPoint.position, Quaternion.identity);
        Rigidbody rb = date.GetComponent<Rigidbody>();

        Vector3 throwDir = Vector3.down + new Vector3(
            Random.Range(-5f, 5f),
            0,
            Random.Range(-5f, 5f)
        );

        rb.linearVelocity = throwDir.normalized * throwForce;
    }
}
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player")]
    public GameObject player;

    [Header("Timer")]
    public float timer;
    private bool gameFinished = false;

    [Header("Checkpoint")]
    public Transform lastCheckpoint;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!gameFinished)
        {
            timer += Time.deltaTime;
        }
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        lastCheckpoint = checkpoint;
        Debug.Log("CHECKPOINT SET: " + checkpoint.name);
    }

    public void RespawnPlayer()
    {
        if (player == null || lastCheckpoint == null) return;

        Vector3 spawnPos = lastCheckpoint.position + Vector3.up * 1.5f;

        Rigidbody rb = player.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            rb.isKinematic = true;
            player.transform.position = spawnPos;
            rb.isKinematic = false;
        }
        else
        {
            player.transform.position = spawnPos;
        }

        Debug.Log("RESPAWN AT: " + lastCheckpoint.name);
    }
}
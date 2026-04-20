using UnityEngine;

public class StageMarker : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        GameManager.Instance.SetCheckpoint(transform);
    }
}
using UnityEngine;

public class StageMarker : MonoBehaviour
{
    private bool oneTime = true;
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Debug.Log("Hitted a Flag" + gameObject.name);

        if (oneTime)
        {
            GameManager.Instance.SetCheckpoint(transform);
            oneTime = false;
        }
    }
}
using UnityEngine;

public class PalmDetector : MonoBehaviour
{
    private PalmTree palmTree;

    void Start()
    {
        palmTree = GetComponent<PalmTree>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            // اللاعب دخل المنطقة، روح للـ PalmTree
            // بس PalmTree بالفعل يتابع المسافة في Update
        }
    }
}
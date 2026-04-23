using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // تأكد أن اللي لمس الناقة هو اللاعب
        if (other.CompareTag("Player"))
        {
            // استدعاء دالة إيقاف التايمر من الـ GameManager
            GameManager.Instance.StopTimer();
        }
    }
}
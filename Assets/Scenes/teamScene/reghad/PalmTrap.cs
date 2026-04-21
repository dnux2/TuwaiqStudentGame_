using UnityEngine;
using UnityEngine.SceneManagement; // ضروري لإعادة تشغيل المرحلة

public class PalmTrap : MonoBehaviour
{
    [Header("إعدادات الفخ")]
    public float speed = 15f;          // سرعة طلوع النخلة (خليتها سريعة للمفاجأة)
    public float targetHeight = 3f;    // الارتفاع المطلوب فوق الأرض
    
    private bool isTriggered = false;
    private Vector3 targetPosition;

    void Start()
    {
        // نحسب المكان النهائي للنخلة بناءً على مكانها الحالي
          targetPosition = transform.position + new Vector3(0, targetHeight, 0);
    }

    void Update()
    {
        // إذا اللاعب فعل الفخ، النخلة تنطلق للأعلى
        if (isTriggered)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // إذا لمس أي شيء يحمل تاغ "Player"
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            
            // ننتظر ثانية بسيطة ثم نعيد المرحلة (أو تقدر تعيدها فوراً)
            Invoke("RestartLevel",8f); 
        }
    }

    void RestartLevel()
    {
        // كود إعادة المرحلة الحالية
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
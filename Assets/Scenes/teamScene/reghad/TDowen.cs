using UnityEngine;

public class TDowen : MonoBehaviour
{
    public Animator palmAnimator; // اسحبي الـ Animator الخاص بالنخلة هنا
    

    public bool oneTimeFall = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!oneTimeFall)
            {
                palmAnimator.SetBool("Fall", true); // تأكدي من اسم الباراميتر في الـ Animator
                oneTimeFall = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            palmAnimator.SetBool("Fall", false); // تأكدي من اسم الباراميتر في الـ Animator
            oneTimeFall = false;
             // إعادة النخلة لوضعها الأصلي
        }
    }
}
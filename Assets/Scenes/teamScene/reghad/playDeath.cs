using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playDeath : MonoBehaviour
{
    public AudioClip startSound;  // صوت "بدينا"
    public AudioClip bulletSound; // صوت الرصاصة
    public AudioClip palmSound;   // صوت النخلة
    private bool isDead = false;

    void Start()
    {
        // تشغيل صوت "بدينا" فور بداية اللعبة
        if (startSound != null)
        {
            AudioSource.PlayClipAtPoint(startSound, transform.position);
        }
    }

    public void HandleDeath(string type)
    {
        if (isDead) return;
        isDead = true;

        if (type == "Bullet")
        {
            StartCoroutine(DeathSequence(bulletSound));
        }
        else if (type == "Palm")
        {
            StartCoroutine(DeathSequence(palmSound));
        }
    }

    IEnumerator DeathSequence(AudioClip clip)
    {
        // 1. تشغيل صوت الموت المحدد
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }

        // 2. تعطيل حركة اللاعب (سكريبت الموفمنت)
        var movment = GetComponent<PlayerMovment>();
        if (movment != null) movment.enabled = false;

        // 3. انتظر 3 ثواني عشان نسمع الصوت
        yield return new WaitForSeconds(3.0f);

        // 4. إعادة تشغيل اللعبة
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
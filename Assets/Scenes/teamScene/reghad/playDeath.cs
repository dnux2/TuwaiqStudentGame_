using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playDeath : MonoBehaviour
{
    public AudioClip startSound;  
    public AudioClip bulletSound; 
    public AudioClip palmSound;   

    private bool isDead = false;

    void Start()
    {
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
        // 1. تشغيل الصوت
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }

        // 2. تعطيل الحركة
        var movment = GetComponent<PlayerMovment>();
        if (movment != null) movment.enabled = false;

        // 3. انتظار
        yield return new WaitForSeconds(3.0f);

        // 4. استدعاء نظام الموت (بدل إعادة تحميل مباشرة)
        Die();
    }

    void Die()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RespawnPlayer();
        }
        else
        {
            Debug.LogWarning("مدير اللعبة مفقود! جارٍ إعادة تحميل المشهد.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
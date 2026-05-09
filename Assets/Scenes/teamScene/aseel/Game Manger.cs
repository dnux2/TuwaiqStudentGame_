//Game manger Script
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player")] public GameObject player;

    [Header("Timer")] public float timer;
    private bool gameFinished = false;

    [Header("Checkpoint")] public Transform lastCheckpoint;

    void Awake()
    {
        // تأكد ما فيه أكثر من GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        if (!gameFinished)
        {
            timer += Time.deltaTime;
        }
    }

    // استدعاء عند لمس الفلاق
    public void SetCheckpoint(Transform checkpoint)
    {
        lastCheckpoint = checkpoint;
        Debug.Log("CHECKPOINT SET: " + checkpoint.name);
    }

    public void RespawnPlayer()
    {
        if (player == null)
        {
            Debug.LogWarning("Player مفقود!");
            return;
        }

        if (lastCheckpoint == null)
        {
            Debug.LogWarning("ما فيه Checkpoint! إعادة تحميل المشهد...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

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

        // 🔥 رجّع سكربت الحركة
        var movement = player.GetComponent<PlayerMovment>();
        if (movement != null)
        {
            movement.enabled = true;
        }

        Debug.Log("RESPAWN AT: " + lastCheckpoint.name);
    }

    public TMP_Text timerText;
    public GameObject winPanel;

    public void StopTimer()
    {
        gameFinished = true;
        Debug.Log("التايمر وقف عند: " + timer);
        timerText.text = timer.ToString("F2") + "s";
        winPanel.SetActive(true);

    }

    public void M()
    {
       SceneManager.LoadScene("Mnue");
       //Debug.Log("Exit");
       //Application.Quit();
    }
}
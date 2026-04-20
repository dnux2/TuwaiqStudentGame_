using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(Vector3.forward * move.magnitude * speed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Debug.Log("اللاعب انضرب!");
            Die();
        }
    }

    void Die()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RespawnPlayer();
        }
        else
        {
            Debug.LogWarning("GameManager missing! Reloading scene.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
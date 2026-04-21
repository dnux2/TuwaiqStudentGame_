using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public Transform cam;
    private Rigidbody rb;
    private playDeath deathScript; // ربط مع سكريبت الموت

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        deathScript = GetComponent<playDeath>();
    }

    void Update()
    {
        // كود المشي والقفز حقك (بدون تغيير)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = (cam.forward * moveZ + cam.right * moveX);
        move.y = 0;
        if (move != Vector3.zero) {
            transform.Translate(move.normalized * Time.deltaTime * speed, Space.World);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * 5f);
        }
        if (Input.GetKeyDown(KeyCode.Space)) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            if (deathScript != null) deathScript.HandleDeath("Bullet");
        }
        else if (other.gameObject.CompareTag("Enemy")) // تأكدي تاغ النخلة Enemy
        {
            if (deathScript != null) deathScript.HandleDeath("Palm");
        }
    }
}
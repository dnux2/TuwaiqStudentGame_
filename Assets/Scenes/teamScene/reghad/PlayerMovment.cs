using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Animator animator;

    public float speed = 5f;
    public float jumpForce = 7f;
    public Transform cam;
    public Rigidbody rb;
    public playDeath deathScript; // ربط مع سكريبت الموت

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        deathScript = GetComponent<playDeath>();
    }

    private bool isWalking = false;
    
        
    void Update()
    {
        // كود المشي والقفز حقك (بدون تغيير)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = (cam.forward * moveZ + cam.right * moveX);
        move.y = 0;
        if (move != Vector3.zero) {
            transform.Translate(move.normalized * Time.deltaTime * speed, Space.World);
        }
        
        float mouseX = Input.GetAxis("Mouse X");
        transform.eulerAngles += new Vector3(0, mouseX, 0);
        
        float mouseY = Input.GetAxis("Mouse Y");
        cam.eulerAngles -= new Vector3(mouseY, 0, 0);
        
        
        if (Input.GetKeyDown(KeyCode.Space)) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
        
        // Check for qnimqtion
        isWalking = (moveX != 0 || moveZ != 0);
        animator.SetBool("isWaking", isWalking);
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
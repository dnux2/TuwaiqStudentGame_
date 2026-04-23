using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Animator animator;

    public float speed = 5f;
    public float jumpForce = 7f;
    public Transform cam;
    public Rigidbody rb;
    public AudioSource audioSource;
    public playDeath deathScript; // ربط مع سكريبت الموت

    private bool isWalking = false;
    private bool isPlayingWalkSound = false;
    public bool isDead = false;
//// أول شيء: تأكد ما نستدعي الموت مرتين
// if (isDie) return;
// 
// // ثاني شيء: شغّل الأنميشن مباشرة
// animator.SetBool("isDie", true);
// isDie = true;
// 
// // ثالث شيء: ثم استدعِ deathScript
// if (deathScript != null)
// {
//     deathScript.HandleDeath("Bullet");
// }

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
        }
        
        float mouseX = Input.GetAxis("Mouse X");
        transform.eulerAngles += new Vector3(0, mouseX, 0);
        
        float mouseY = Input.GetAxis("Mouse Y");
        cam.eulerAngles -= new Vector3(mouseY, 0, 0);
        
        
        if (Input.GetKeyDown(KeyCode.Space)) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
        isWalking = (moveX != 0 || moveZ != 0);
        animator.SetBool("isWaking", isWalking);

        // 🔊 صوت المشي
        if (isWalking)
        {
            if (!isPlayingWalkSound && audioSource != null)
            {
                audioSource.Play();
                isPlayingWalkSound = true;
            }
        }
        else
        {
            if (isPlayingWalkSound && audioSource != null)
            {
                audioSource.Stop();
                isPlayingWalkSound = false;
            }
        }
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
            animator.SetBool("isDie", true);
            if (deathScript != null) deathScript.HandleDeath("Palm");
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce =7f; // تعريف قوة القفز
    private Rigidbody rb;        // تعريف متغير الفيزياء

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        // ربط المتغير بمكون الـ Rigidbody الموجود على اللاعب
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // كود القفز
        if (Input.GetKeyDown(KeyCode.Space))
        {
           rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        // Vector3.forward عشان يمشي لجهة وجهه
    // ونستخدم move.magnitude عشان نعرف هل هو ضاغط أزرار ولا واقف
       Vector3 move = new Vector3(moveX, 0, moveZ);
       transform.Translate(Vector3.forward * move.magnitude * speed * Time.deltaTime);
       if (move != Vector3.zero)
       {
        transform.forward = move;
        }
    
        
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Bullet"))
         {
            Destroy(other.gameObject);
             Debug.Log("اللاعب انضرب!");
            Die();
         }
    }
    void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}

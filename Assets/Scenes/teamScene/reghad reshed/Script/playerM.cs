using UnityEngine;
 
public class PlayerM : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 200f;
     private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
       // if (Input.GetKey(KeyCode.A)
        {
         //   an.SetTrigger("walking");

        }



    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        Vector3 movement = transform.forward * move * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        Quaternion rotation = Quaternion.Euler(0f, turn * turnSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * rotation);
    }
}
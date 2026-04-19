using UnityEngine;
using System.Collections;
public class FallenTree : MonoBehaviour
{
    public float JumpForce; 
    public Rigidbody rb;
    public void Start()
    {
      //  StartCoroutine(TreeFall());
    }

    private bool isJumped;
    void OnTriggerEnter(Collider other)
    {
        if (isJumped) return;
        
        if (other.tag == "Player")
        {
            StartCoroutine(TreeFall());
        }
    }

    IEnumerator TreeFall()
    {
        yield return new WaitForSeconds(2);
        rb.isKinematic = false;
        
        
        Jump = true;
        yield return new WaitForSeconds(appearTime);
        Jump = false;
        rb.isKinematic = true;
        //rb.useGravity = true;

    }
    bool Jump= false;
    public float appearTime;
    void Update()
    {
        if (Jump)
        {
            rb.linearVelocity += Vector3.up * JumpForce;
        }
    }
}

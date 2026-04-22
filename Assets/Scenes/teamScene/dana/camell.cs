using UnityEngine;
using UnityEngine.SceneManagement;
public class CarMove : MonoBehaviour
{
    public float speed = 5f;
    private bool move = false;

    void Update()
    {
        if (move)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            move = true; 
            SceneManager.LoadScene("Game");

        }
    }

   
}
/*
   using UnityEngine;

public class CarMove : MonoBehaviour
{
   public float speed = 5f;
   private bool move = false;

   void Update()
   {
       if (move)
       {
           transform.Translate(Vector3.forward * speed * Time.deltaTime);
       }
   }

   // Ì»œ√ «·Õ—ﬂ… ·„« ÌœŒ· «··«⁄» «· —Ìﬁ—
   void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("Player"))
       {
           move = true;
       }
   }

   // Â‰« Ì’œ„ «··«⁄»
   void OnCollisionEnter(Collision collision)
   {
       if (collision.gameObject.CompareTag("Player"))
       {
           collision.gameObject.GetComponent<PlayerDeath>().Die();
       }
   }
}
*/
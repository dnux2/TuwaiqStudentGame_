using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;

    void Update()
    {
        bool isWalking = Input.GetKey(KeyCode.A);

        // «” Œœ„Ì ‰›” «·«”„ »«·÷»ÿ
        animator.SetBool("isWaking", isWalking);

        if (isWalking)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
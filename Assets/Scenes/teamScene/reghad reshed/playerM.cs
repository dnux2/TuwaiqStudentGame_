using UnityEngine;

public class playerM : MonoBehaviour
{
    public Rigidbody PlayerPhyx;
    public Animator an;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.N)) {
            an.SetTrigger("walking");
        }
    }
}

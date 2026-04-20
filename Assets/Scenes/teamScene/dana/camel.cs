using UnityEngine;

public class camel : MonoBehaviour
{
    public float speed = 5f; // ”—⁄… «·‰«ﬁ…

    void Update()
    {
        //  „‘Ì ··√„«„ »‘ﬂ· „” „— »œÊ‰ √Ì “—
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
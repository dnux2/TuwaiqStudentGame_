using UnityEngine;

public class CatAutoMove : MonoBehaviour
{
    public float speed = 1f;
    public float changeTime = 3f;

    private Vector3 direction;
    private float timer;

    void Start()
    {
        PickRandomDirection();
    }

    void Update()
    {
        // حركة
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // دوران باتجاه الحركة
        if (direction != Vector3.zero)
            transform.forward = direction;

        // تغيير الاتجاه كل كم ثانية
        timer += Time.deltaTime;
        if (timer >= changeTime)
        {
            PickRandomDirection();
            timer = 0f;
        }
    }

    void PickRandomDirection()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        direction = new Vector3(x, 0, z).normalized;
    }

    void OnCollisionEnter(Collision collision)
    {
     
        if (collision.gameObject.CompareTag("Wall"))
        {
            PickRandomDirection();
        }
    }
}
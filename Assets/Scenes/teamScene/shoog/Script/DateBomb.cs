using UnityEngine;

public class DateBomb : MonoBehaviour
{
    [Header("الملاحقة")]
    public float speed = 10f;
    public float rotateSpeed = 5f;
    public float delayBeforeChase = 0.4f;

    [Header("الوقت")]
    public float lifeTime = 3f;

    [Header("التصادم")]
    public float collisionDelay = 0.1f;

    [Header("الانفجار")]
    public GameObject explosionPrefab;

    private Transform player;
    private Rigidbody rb;

    private float chaseTimer = 0f;
    private float lifeTimer = 0f;

    private bool isChasing = false;
    private bool canExplode = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // ✅ الجاذبية شغالة عشان تطيح وتتحرج
        rb.useGravity = true;

        // إعدادات فيزيائية تساعد على التدحرج
        rb.linearDamping = 0.5f;
        rb.angularDamping = 0.5f;

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;

        Invoke(nameof(EnableCollision), collisionDelay);
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // تأخير قبل الملاحقة
        chaseTimer += Time.fixedDeltaTime;
        if (chaseTimer >= delayBeforeChase)
            isChasing = true;

        // مؤقت الانفجار التلقائي
        lifeTimer += Time.fixedDeltaTime;
        if (lifeTimer >= lifeTime)
        {
            Explode(false);
            return;
        }

        if (isChasing)
        {
            // اتجاه اللاعب (نلغي المحور Y عشان ما تطير)
            Vector3 dir = player.position - transform.position;
            dir.y = 0f;
            dir.Normalize();

            // دوران باتجاه اللاعب
            Quaternion targetRot = Quaternion.LookRotation(dir);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRot, rotateSpeed * Time.fixedDeltaTime));

            // حركة للأمام (قوة)
            rb.AddForce(dir * speed, ForceMode.Force);

            // دوران يخليها تتحرج
            rb.AddTorque(transform.right * speed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!canExplode) return;

        // ✅ تنفجر فقط إذا لمست اللاعب
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("💀 اللاعب مات!");
            // collision.gameObject.GetComponent<PlayerHealth>().Die();
            Explode(true);
        }

        // ❌ تجاهل الأرض وأي شي ثاني
    }

    void EnableCollision()
    {
        canExplode = true;
    }

    void Explode(bool hitPlayer)
    {
        if (explosionPrefab != null)
        {
            GameObject fx = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(fx, 2f);
        }

        Destroy(gameObject);
    }
}
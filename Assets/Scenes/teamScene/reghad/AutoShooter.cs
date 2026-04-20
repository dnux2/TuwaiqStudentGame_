using UnityEngine;

public class AutoShooter : MonoBehaviour
{
     public GameObject bulletPrefab; 
    public Transform firePoint;     
    public Transform player;        
    public float shootingRange = 20f;
    public float bulletSpeed = 15f;
    public float fireRate = 1.2f;

    private float nextFireTime;

    void Update()
    {
        // حساب المسافة
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= shootingRange)
        {
            // يخلي السلاح يلف ويطالع في اللاعب
            transform.LookAt(player);

            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        // إنشاء الرصاصة في مكان الـ FirePoint بالضبط
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // دفع الرصاصة للأمام باتجاه ما يطالع السلاح
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }

        // تدميرها بعد 4 ثواني عشان ما تعبي المشهد
        Destroy(bullet, 10f);
    }
}

using UnityEngine;

public class Shooter : MonoBehaviour
{
    
    public GameObject bulletPrefab; 
    public Transform firePoint;    
    public float bulletSpeed = 50f;
    public float shootInterval = 2f; // الوقت بين كل رصاصة ورصاصة (ثانيتين)

    
    void Start()
    {
        // هذي الدالة تشغل وظيفة Shoot وتكررها كل ثانيتين
        InvokeRepeating("Shoot", 1f, shootInterval);
    }
   
    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = firePoint.forward * bulletSpeed;
            }
            
            Destroy(bullet,10f); // تمسح الرصاصة بعد 3 ثواني عشان الزحمة
        }
    }
}

using UnityEngine;

public class GunTrigger : MonoBehaviour
{
    public GameObject theGun; // اسحب السلاح (Rifle) هنا

    void Start() {
        theGun.SetActive(false); // السلاح يكون مخفي في البداية
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            theGun.SetActive(true); // يظهر السلاح لما يدخل اللاعب
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            theGun.SetActive(false); // يختفي السلاح لما يطلع اللاعب
        }
    }
}

using UnityEngine;

public class FlagRise : MonoBehaviour
{
    public Transform flag;        // ÇáÚáã
    public float riseHeight = 3f; // ßã íÑÊİÚ
    public float speed = 2f;      // ÓÑÚÉ ÇáÇÑÊİÇÚ

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool shouldRise = false;

    void Start()
    {
        startPos = flag.position;
        targetPos = startPos + new Vector3(0, riseHeight, 0);
    }

    void Update()
    {
        if (shouldRise)
        {
            flag.position = Vector3.Lerp(flag.position, targetPos, Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // áãÇ ÇááÇÚÈ íáãÓ
        {
            shouldRise = true;
        }
    }
}
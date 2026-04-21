
using UnityEngine;

public class FlagRise : MonoBehaviour
{
    public Transform flag;        // �����
    public float riseHeight = 3f; // �� �����
    public float speed = 2f;      // ���� ��������

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

    bool oneTime = true;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ��� ������ ����
        {
            shouldRise = true;
            if (oneTime)
            {
                oneTime = false;
                GameManager.Instance.SetCheckpoint(transform);
            }
        }
    }
}
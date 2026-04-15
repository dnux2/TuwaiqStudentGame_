using UnityEngine;
using UnityEngine.SceneMangement;
public class TreeMovement : MonoBehaviour
{
    public float riseHeight = 5f;
    public float riseSpeed = 15f;
    private Vector3 startPos;
    private Vector3 targetPos;
    private bool isActivated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.up;

    }
    void OnTraiggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }    
    }
    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos, riseSpeed * Time.deltaTime);
        }
    }
}

using UnityEngine;

public class TrampolineMovement : MonoBehaviour
{
    public Vector3 direction;
    public float moveSpeed;
    public float moveTime;
    private float time;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
	{
        time += Time.deltaTime;
        if(time > moveTime)
        {
            time = 0;
            direction = direction * -1;
        }
        rb.position += direction * Time.deltaTime * moveSpeed;
	}
}

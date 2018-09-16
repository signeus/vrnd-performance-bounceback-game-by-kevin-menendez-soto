using UnityEngine;

public class TrampolineMovement : MonoBehaviour
{
    public Vector3 direction;
    public float moveSpeed;
    public float moveTime;
    private float time;
																									
	void Update()
	{
        time += Time.deltaTime;
        if(time > moveTime)
        {
            time = 0;
            direction = direction * -1;
        }
        transform.position += direction * Time.deltaTime * moveSpeed;
	}
}

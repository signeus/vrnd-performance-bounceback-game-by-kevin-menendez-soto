using UnityEngine;

public class Ball : MonoBehaviour
{
	public Rigidbody rigidbody;
	private Vector3 vector3_zero = Vector3.zero;
	public bool ballStopped = true;
	[Tooltip("Lowest speed for ball to consider as stopped")]
	public float lowestSpeed;

	public float currentSpeed = 0;

	void Awake()
	{
		gameObject.SetActive(false);
	}

	public void Activate(Vector3 startingPosition)
	{
		rigidbody.velocity = vector3_zero;
		rigidbody.angularVelocity = vector3_zero;
		transform.position = startingPosition;
		gameObject.SetActive(true);
		ballStopped = false;
	}

	void Update()
	{
		if(rigidbody.isKinematic == false)
		{
			currentSpeed = rigidbody.velocity.magnitude;
			if(rigidbody.velocity.magnitude <= lowestSpeed && ballStopped == false)
			{
				ballStopped = true;
			}
			else if(rigidbody.velocity.magnitude > lowestSpeed && ballStopped)
				ballStopped = false;
		}
		else if(ballStopped)
			ballStopped = false;
	}
}

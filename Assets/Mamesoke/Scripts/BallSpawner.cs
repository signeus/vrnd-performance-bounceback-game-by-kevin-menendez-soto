using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
	public bool spawnBall;
    public static BallSpawner current;

    public GameObject pooledBallPrefab;
    [Tooltip("Number of Balls you want in the object pool when game starts")]
    public int initialBallsLimit;
    public List<Ball> ball;
    public static int currentBallNum = -1; //a number used to cycle through the pooled objects
    private int count;

    private float cooldown;
	[Tooltip("Interval between spawning balls")]
    public float cooldownLength = 0.5f; // This is the timer for a new respawn.

    public GameManager GM;
    private int i;

    void Awake()
    {
        current = this;
    }

    void Start()
    {
        ball = new List<Ball>();
		for (i = 0; i < initialBallsLimit; i++)
			AddNewBall(i);
    }

    private void AddNewBall(int ballNum)
	{
		GameObject newBallGameObject = Instantiate(pooledBallPrefab);
		Ball newBall = newBallGameObject.GetComponent<Ball>();
		ball.Add(newBall);
	}

	private void SpawnBall()
	{
        // This method is for reuseable the objects in a object pool (Better performance)
		currentBallNum++;
		count = 0;
		while(count < ball.Count)
		{
			if(currentBallNum >= ball.Count)
				currentBallNum = 0;
			if(ball[currentBallNum].gameObject.activeSelf == false || ball[currentBallNum].ballStopped)
			{
				ball[currentBallNum].Activate(transform.position);
				return;
			}
			currentBallNum++;
			count++;
		}
		AddNewBall(ball.Count);

		ball[ball.Count-1].Activate(transform.position);
		currentBallNum = -1;
	}
   																									
	void Update()
	{
		if(spawnBall)
		{
			cooldown -= Time.deltaTime;
			if(cooldown <= 0)
			{
				cooldown = cooldownLength;
				SpawnBall();
			}
		}	
	}
}

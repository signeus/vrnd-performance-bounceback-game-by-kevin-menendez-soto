using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public bool showDebug;
    public float gameDuration;
    private float timeRemaining = 0;
    public bool gameEnded = true;

    public Text time_text;
    public Text score_text;


    public Text fps_text;
    private float fpsDeltaTime;
    private int fps;

    private OVRInput.Controller leftController;
    private OVRInput.Controller rightController;

    void Start()
	{
		ResetGame();
        leftController = OVRInput.Controller.LTouch;
        rightController = OVRInput.Controller.RTouch;
    }

	private void ResetGame()
	{
		timeRemaining = gameDuration;
		gameEnded = false;
		score = 0;
		score_text.text = score.ToString();
	}
	
	void Update()
	{
		if(!gameEnded)
		{
			timeRemaining = timeRemaining - Time.deltaTime;
			if(timeRemaining <= 0)
			{
				timeRemaining = 0;
				gameEnded = true;
				time_text.text = "<color=#ff4242><b>Finish!</b></color>";
			}
			else
				time_text.text = ((int)timeRemaining + 1).ToString();
		}

		if(OVRInput.GetDown(OVRInput.Button.One, leftController) || OVRInput.GetDown(OVRInput.Button.Two, leftController) 
            || OVRInput.GetDown(OVRInput.Button.One, rightController) || OVRInput.GetDown(OVRInput.Button.Two, rightController))
		{
			ResetGame();
		}

		if(OVRInput.GetDown(OVRInput.Button.Start, leftController) || OVRInput.GetDown(OVRInput.Button.Start, rightController))
        {
			Application.Quit();
		}

		UpdateFPS();
	}

	public void IncrementScore(int value)
	{
		score += value;
		score_text.text = score.ToString();
	}

	public void UpdateFPS()
	{
		fpsDeltaTime += (Time.unscaledDeltaTime - fpsDeltaTime) * 0.1f;
		fps = (int)(1.0f / fpsDeltaTime);
		fps_text.text = "FPS: " + fps;
	}
}
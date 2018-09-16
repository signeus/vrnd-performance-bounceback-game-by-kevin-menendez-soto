using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public ParticleSystem pSystem;
	public GameManager GM;
    
    void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.CompareTag("Throwable"))
		{
			if(!GM.gameEnded)
			{
				GM.IncrementScore(1);
				pSystem.Play();
			}
        }
    }
}

using UnityEngine;
using System.Collections;

public class PlayerStat : MonoBehaviour {
	public float playerHealth;
	public bool isHurt;
	Animator anim;

	void Start()
	{	
		anim = gameObject.GetComponent<Animator> ();
		playerHealth = 10;
	}

	public void takeDamage(float damage)
	{
		playerHealth -= damage;
		GetComponents<AudioSource>()[1].Play();
		GetComponents<AudioSource>()[2].Play();

		if(playerHealth == 0)
		{
			anim.SetTrigger("Death");

		}
	}

	public void recoverDamage(float heal)
	{
		playerHealth += heal;
	}

	public void Update()
	{
		anim.SetBool ("isHurt", isHurt);

	}
	public void Death()
	{
		
		Application.LoadLevel("MainMenuScene");
	}

}

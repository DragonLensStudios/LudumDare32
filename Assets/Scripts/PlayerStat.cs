using UnityEngine;
using System.Collections;

public class PlayerStat : MonoBehaviour {
	public float playerHealth;

	void Start()
	{
		playerHealth = 20;
	}

	public void takeDamage(float damage)
	{
		playerHealth -= damage;
		if(playerHealth == 0)
		{

			Application.LoadLevel("MainMenuScene");
		}
	}

	public void recoverDamage(float heal)
	{
		playerHealth += heal;
	}
}

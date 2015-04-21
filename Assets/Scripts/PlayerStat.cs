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
			//Play game over/death sequence
		}
	}

	public void recoverDamage(float heal)
	{
		playerHealth += heal;
	}
}

using UnityEngine;
using System.Collections;

public class PlayerHitbox : MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{
		// must have hit an enemy or enemy bullet
		// lose a life
//		GameManager.lives--;
		
		// check if we were hit by a bullet, if so put it back on its stack
		if (other.CompareTag("enemyBullet"))
		{
			GameMaster.enemyBulletStack.Push(other.gameObject);
	 		other.gameObject.SetActive(false); // deactivate the bullet
		}
		else if (other.CompareTag("Enemy"))
		{
			// if it was an enemy, just destroy it
//			other.GetComponent<Enemy>().Explode();
			GameMaster.lives--;
			other.GetComponent<Enemy>().TakeDamage(1);
		}
	}
}

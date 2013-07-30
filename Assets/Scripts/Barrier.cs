using UnityEngine;
using System.Collections;


// Barriers catch objects which have left the screen (such as bullets or enemies)
// and puts them back in the correct stack for later re-use
public class Barrier : MonoBehaviour {
	
	// a bullet has entered this barrier - check what type it is and put it back on the correct stack
	void OnTriggerEnter (Collider other) 
	{
		if (other.CompareTag("Bullet")) // was this a player bullet?
		{
			// put the bullet back on the stack for later re-use
			GameMaster.playerBulletStack.Push(other.gameObject); // push the Bullet component, not the collider
			other.gameObject.SetActive(false); // deactivate the bullet
		}
		else if( other.CompareTag("Bullet2") )
		{
			GameMaster.playerBulletStack2.Push(other.gameObject); // push the Bullet component, not the collider
			other.gameObject.SetActive(false); // deactivate the bullet
		}
		else if (other.CompareTag("enemyBullet")) // was this an enemy bullet?
		{
			GameMaster.enemyBulletStack.Push(other.gameObject);
			other.gameObject.SetActive(false); // deactivate the bullet
		}
	}
}

/*
 * Do HighScores scumbag
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour {
	StartMenu settings;
	Player player1;
	
	public int difficulty;
	public int sfxVol;
	public int bgmVol;

	public static int lives;	// Player lives
	public static int score;	// Player score
	public static int level;	// Current Level
	
	public GameObject playerBullet;	// Player Bullet Prefab
	public GameObject playerBullet2;
	public GameObject enemyBullet;	// Enemy Bullet Prefab
	
	public int playerBulletPoolSize = 25;
	public int enemyBulletPoolSize  = 25;
	
	public static Stack<GameObject> playerBulletStack = new Stack<GameObject>();	// a stack to store all the player bullets
	public static Stack<GameObject> playerBulletStack2 = new Stack<GameObject>();	// a stack to store the player's 2ndary bullets
//	public static Stack<GameObject> enemyBulletStack = new Stack<GameObject>();		// a stack to store all the enemy bullets
	
	// Use this for initialization
	void Start () {
		if( PlayerPrefs.HasKey( "sfxVol" ) )
			sfxVol = PlayerPrefs.GetInt( "sfxVol" );
		else
			sfxVol = 50;
		
		if( PlayerPrefs.HasKey( "bgmVol" ) )
			bgmVol = PlayerPrefs.GetInt( "bgmVol" );
		else
			bgmVol = 50;
		
		if( PlayerPrefs.HasKey( "difficulty" ) )
			difficulty = PlayerPrefs.GetInt( "difficulty" );
		else
			difficulty = 5;
		
		
		InitBulletPools();
	}
	
	// Initiates the Bullet Pools for player and enemy
	void InitBulletPools() {
		GameObject bulletPool = new GameObject("Bullet Pool");
		
		// Player Bullet Pool
		for (int i = 0; i < playerBulletPoolSize; i++)
		{
			GameObject newBullet = Instantiate (playerBullet, Vector3.zero, Quaternion.identity) as GameObject; // create a bullet
			newBullet.transform.parent = bulletPool.transform;
			newBullet.gameObject.SetActive(false);	// disable it until it's needed
			playerBulletStack.Push(newBullet);		// put it on the stack
		}
		
		for(int i = 0; i < playerBulletPoolSize; i++)
		{
			GameObject newBullet = Instantiate(playerBullet2, Vector3.zero, Quaternion.identity) as GameObject;
			newBullet.transform.parent = bulletPool.transform;
			newBullet.gameObject.SetActive(false);	// disable it until it's needed
			playerBulletStack2.Push(newBullet);		// put it on the stack
		}
		
		
		// Enemy Bullet Pool
//		for (int i = 0; i < enemyBulletPoolSize; i++)
//		{
//			GameObject newBullet = Instantiate (enemyBullet, Vector3.zero, Quaternion.identity) as GameObject; // create a bullet
//			newBullet.transform.parent = bulletPool.transform;
//			newBullet.gameObject.SetActive(false);	// disable it until it's needed
//			enemyBulletStack.Push(newBullet);		// put it on the stack
//		}
		
	}
}


struct playerScore{
	string name;
	int score;
};
/*
 * Do HighScores scumbag
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour {
	StartMenu settings;
	Player player1;
	Player player2;
	public int difficulty;
	public int sfxVol;
	public int bgmVol;
	int curScore;
	int curLevel;
	int player1Lives;
	int player2Lives;
	public GameObject playerBullet;
	public static Stack<GameObject> playerBulletStack = new Stack<GameObject>(); // a stack to store all the player bullets
	public static Stack<GameObject> enemyBulletStack = new Stack<GameObject>(); // a stack to store all the enemy bullets
	
	// Use this for initialization
	void Start () {
//		if( PlayerPrefs.HasKey( "sfxVol" ) )
//			sfxVol = PlayerPrefs.GetInt( "sfxVol" );
//		else
//			sfxVol = 50;
//		
//		if( PlayerPrefs.HasKey( "bgmVol" ) )
//			bgmVol = PlayerPrefs.GetInt( "bgmVol" );
//		else
//			bgmVol = 50;
//		
//		if( PlayerPrefs.HasKey( "difficulty" ) )
//			difficulty = PlayerPrefs.GetInt( "difficulty" );
//		else
//			difficulty = 5;
		
		for (var i = 0; i < 25; i++)
		{
			GameObject newBullet = Instantiate (playerBullet, Vector3.zero, Quaternion.identity) as GameObject; // create a bullet
			newBullet.gameObject.SetActive(false); // disable it until it's needed
			playerBulletStack.Push(newBullet); // put it on the stack
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}


struct playerScore{
	string name;
	int score;
};
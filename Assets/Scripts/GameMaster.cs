/*
 * Do HighScores scumbag
 */
using UnityEngine;
using System.Collections;

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
		print( sfxVol );
		print ( bgmVol );
		print ( difficulty );
	}
	
	// Update is called once per frame
	void Update () {
	}
}


struct playerScore{
	string name;
	int score;
};
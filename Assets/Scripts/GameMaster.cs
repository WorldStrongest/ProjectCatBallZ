/*
 * Do HighScores scumbag
 */
using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	Player player1;
	Player player2;
	int difficulty;
	int sfxVol;
	int bgVol;
	int curScore;
	int curLevel;
	int player1Lives;
	int player2Lives;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}


struct playerScore{
	string name;
	int score;
};
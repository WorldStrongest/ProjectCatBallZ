//Enemy version 2

using UnityEngine;
using System.Collections;

public class Enemy2 : Enemy {
	public GameObject[] bullet;
	float[] nextBullet;
	public float[] nextCD;
	public bool[] shotFired;
	bool firstShot;
	float sprayCD;
	public float nextShotInSpray;
	public int counter;
	public int totalShots;
	
	
	
	// Use this for initialization
	void Start () {
		_transform = transform;
		nextShot = cooldown;
		nextBullet = new float[totalShots];
		shotFired = new bool[totalShots];
		for( int i = 0; i < totalShots; ++i ){
			nextBullet[i] = nextCD[i];
			shotFired[i] = false;
		}
			
		Target( "Player" );
		firstShot = true;
	}
	
	// Update is called once per frame
	void Update () {
		_transform.position += Vector3.down*(speed*Time.deltaTime);
		
		if( Time.time > nextShot ){
			if( firstShot ){
				firstShot = false;
				nextBullet[0] = Time.time + nextCD[0];
				shotFired[0] = false;
				counter = 0;
				for( int i = 1; i < totalShots; ++i ){
					nextBullet[i] = nextBullet[i-1] + nextCD[i];
					shotFired[i] = false;
				}
			}
			if( !shotFired[4] && Time.time > nextBullet[4] ){
				Instantiate( bullet[4], _transform.position, Quaternion.identity );
				nextShot = Time.time + cooldown;
				firstShot = true;
				shotFired[4] = true;
			}
			else if( !shotFired[3] && Time.time > nextBullet[3] ){
				Instantiate( bullet[3], _transform.position, Quaternion.identity );
				shotFired[3] = true;
			}
			else if( !shotFired[2] && Time.time > nextBullet[2] ){
				Instantiate( bullet[2], _transform.position, Quaternion.identity );
				shotFired[2] = true;
			}
			else if( !shotFired[1] && Time.time > nextBullet[1] ){
				Instantiate( bullet[1], _transform.position, Quaternion.identity );
				shotFired[1] = true;
			}
			else if( !shotFired[0] && Time.time > nextBullet[0] ){
				Instantiate( bullet[0], _transform.position, Quaternion.identity );
				shotFired[0] = true;
			}
//			_go.GetComponent<Bullet>().cooldown
			
		}
	}
}

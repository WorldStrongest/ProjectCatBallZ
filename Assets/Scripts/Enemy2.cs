//Shots spaced out from time
//Method to create patterns
//Need to create another gap to give time inbetween patterns

using UnityEngine;
using System.Collections;

public class Enemy2 : Enemy {
	Transform _transform;
	float[] nextBullet;
	float[] nextCD;
	public bool[] shotFired;
	bool firstShot;
	
	
	
	// Use this for initialization
	void Start () {
		_transform = transform;
		nextShot = cooldown;
		nextBullet = new float[5];
		nextCD = new float[5];
		shotFired = new bool[5];
		for( int i = 0; i < 5; ++i ){
			nextCD[i] = 1f;
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
				for( int i = 0; i < 5; ++i ){
					nextBullet[i] = Time.time + nextCD[i]*i;
					shotFired[i] = false;
				}
			}
			if( !shotFired[4] && Time.time > nextBullet[4] ){
				Instantiate( enemyBullet, _transform.position, Quaternion.LookRotation(Vector3.forward, _target.position - _transform.position) );
				nextShot = Time.time + cooldown;
				firstShot = true;
				shotFired[4] = true;
			}
			else if( !shotFired[3] && Time.time > nextBullet[3] ){
				Instantiate( enemyBullet, _transform.position, Quaternion.identity );
				shotFired[3] = true;
			}
			else if( !shotFired[2] && Time.time > nextBullet[2] ){
				Instantiate( enemyBullet, _transform.position, Quaternion.LookRotation(Vector3.forward, _target.position - _transform.position) );
				shotFired[2] = true;
			}
			else if( !shotFired[1] && Time.time > nextBullet[1] ){
				Instantiate( enemyBullet, _transform.position, Quaternion.identity );
				shotFired[1] = true;
			}
			else if( !shotFired[0] && Time.time > nextBullet[0] ){
				Instantiate( enemyBullet, _transform.position, Quaternion.LookRotation(Vector3.forward, _target.position - _transform.position) );
				shotFired[0] = true;
			}
//			_go.GetComponent<Bullet>().cooldown
			
		}
	}
}

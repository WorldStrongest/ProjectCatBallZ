//Enemy version 4
//break removed to allow firing 2 shots at the same time
//Laggy

using UnityEngine;
using System.Collections;

[System.Serializable]
public class enemyData{
	public GameObject bullet;
	public float nextCD;
	public float angle;
	public float displacementX;
	public float displacementY;
	public int loopCount;
	public bool shotFired;
	public bool targetFire;
	public bool randomAngle;
};

public class Enemy4 : Enemy {
	public enemyData[] enemyDATA;
	public float[] nextBullet;
	public int totalShots;
	public int localCounter;
	int curShot;
	public bool suicideOnComplete;
	public bool isBullet;
	bool firstShot;
	

	
	// Use this for initialization
	void Start () {
		_transform = transform;
		SetEnemyPath( nodes, easeType, loopType );
		totalShots = enemyDATA.Length;
		nextShot = cooldown;
		nextBullet = new float[totalShots];
		firstShot = true;
		Target( target );
		
		for( int i = 0; i < totalShots; ++i ){
			nextBullet[i] = enemyDATA[i].nextCD;
			enemyDATA[i].shotFired = false;
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
//		_transform.position += Vector3.down*(speed*Time.deltaTime);
		
		if( Time.time > nextShot ){
			if( firstShot ){
				firstShot = false;
				nextBullet[0] = Time.time + enemyDATA[0].nextCD;
				enemyDATA[0].shotFired = false;
				curShot = 0;
				for( int i = 1; i < totalShots; ++i ){
					nextBullet[i] = nextBullet[i-1] + enemyDATA[i].nextCD;
					enemyDATA[i].shotFired = false;
				}
			}
			

			for( int i = 0; i <totalShots; ++i ){
				if( !enemyDATA[i].shotFired && Time.time > nextBullet[i] ){
					if( enemyDATA[i].targetFire )
						Instantiate( enemyDATA[i].bullet, new Vector3( _transform.position.x + enemyDATA[i].displacementX, _transform.position.y + enemyDATA[i].displacementY, 0 ), Quaternion.LookRotation( Vector3.forward, _target.position - _transform.position ) );
					else if( enemyDATA[i].randomAngle )
						Instantiate( enemyDATA[i].bullet, new Vector3( _transform.position.x + enemyDATA[i].displacementX, _transform.position.y + enemyDATA[i].displacementY, 0 ), Quaternion.Euler( 0, 0, Random.Range( -enemyDATA[i].angle, enemyDATA[i].angle ) + 180 ) );
					else if( enemyDATA[i].angle != 0 )
						Instantiate( enemyDATA[i].bullet, new Vector3( _transform.position.x + enemyDATA[i].displacementX, _transform.position.y + enemyDATA[i].displacementY, 0 ), Quaternion.Euler( 0, 0, enemyDATA[i].angle + 180 ) );
					else
						Instantiate( enemyDATA[i].bullet, new Vector3( _transform.position.x + enemyDATA[i].displacementX, _transform.position.y + enemyDATA[i].displacementY, 0 ), Quaternion.Euler( _transform.rotation.x, _transform.rotation.y, _transform.rotation.z + 180 ) );
					enemyDATA[i].shotFired = true;
					
					if( i == totalShots - 1 ){
						if( suicideOnComplete ){
							Destroy( gameObject );
						}
						firstShot = true;
						enemyDATA[totalShots - 1].shotFired = true;
						nextShot = Time.time + cooldown;
					}
//					break;
				}
			}
		}
	}
	
//	void OnTriggerEnter( Collider collider ){
//		if( isBullet ){
//			return;
//		}
//		else if( collider.gameObject.tag == "Player" || hitPoints == 0){
//			Instantiate( onDeathBullet, _transform.position, Quaternion.LookRotation(Vector3.forward, _target.transform.position - _transform.position) ); 
//			
//			Destroy( gameObject );
//			
//			Debug.Log (collider.transform.position);
//		}
//	}
}


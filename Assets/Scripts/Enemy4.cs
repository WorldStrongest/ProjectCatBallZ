//Enemy version 4

using UnityEngine;
using System.Collections;

[System.Serializable]
public class enemyData{
	public GameObject bullet;
	public float nextCD;
	public float angle;
	public bool shotFired;
	public bool targetFire;
	public bool randomAngle;
};

public class Enemy4 : Enemy {
	public enemyData[] enemyDATA;
	public float[] nextBullet;
	public int totalShots;
	public bool suicideOnComplete;
	public bool isBullet;
	bool firstShot;
	

	
	// Use this for initialization
	void Start () {
		_transform = transform;
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
		_transform.position += Vector3.down*(speed*Time.deltaTime);
		
		if( Time.time > nextShot ){
			if( firstShot ){
				firstShot = false;
				nextBullet[0] = Time.time + enemyDATA[0].nextCD;
				enemyDATA[0].shotFired = false;
				for( int i = 1; i < totalShots; ++i ){
					nextBullet[i] = nextBullet[i-1] + enemyDATA[i].nextCD;
					enemyDATA[i].shotFired = false;
				}
			}
			for( int i = totalShots - 1; i >= 0; --i ){
				if( !enemyDATA[i].shotFired && Time.time > nextBullet[i] ){
					if( enemyDATA[i].targetFire )
						Instantiate( enemyDATA[i].bullet, _transform.position, Quaternion.LookRotation( Vector3.forward, _target.position - _transform.position ) );
					else if( enemyDATA[i].randomAngle )
						Instantiate( enemyDATA[i].bullet, _transform.position, Quaternion.Euler( 0, 0, Random.Range( -enemyDATA[i].angle, enemyDATA[i].angle ) ) );
					else if( enemyDATA[i].angle != 0 )
						Instantiate( enemyDATA[i].bullet, _transform.position, Quaternion.Euler( 0, 0, enemyDATA[i].angle ) );
					else
						Instantiate( enemyDATA[i].bullet, _transform.position, _transform.rotation );
					enemyDATA[i].shotFired = true;
					if( i == totalShots - 1 ){
						if( suicideOnComplete ){
							Destroy( gameObject );
						}
						firstShot = true;
						enemyDATA[totalShots - 1].shotFired = true;
						nextShot = Time.time + cooldown;
					}
					break;
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


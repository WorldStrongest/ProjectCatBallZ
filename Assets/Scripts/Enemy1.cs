//Random Spray

using UnityEngine;
using System.Collections;

public class Enemy1 : Enemy {
	public int bulletCount;
	float sprayCD;
	public float nextShotInSpray;
	public int counter;
	public float angle;
	
	// Use this for initialization
	void Start () {
		_transform = transform;
		nextShot = cooldown;
		sprayCD = cooldown/bulletCount;
		nextShotInSpray = sprayCD;
		counter = 0;
		Target ( "Player" );
	}
	
	// Update is called once per frame
	void Update () {
		_transform.position += Vector3.down*(speed*Time.deltaTime);
		
		if( Time.time > nextShot ){
			RandomSpray( angle );
//			triShot ( );
			if( counter == bulletCount ){
				counter = 0;
//			_transform.Rotate( new Vector3( 0, 0, 30 ) );
				nextShot = Time.time + cooldown;
			}
		}
		
		if( _transform.position.y < -115.0f || Mathf.Abs( _transform.position.x ) > 200.0f ) {
			Destroy( gameObject );
		}
	}
	
	void OnTriggerEnter( Collider collider ){
		if( collider.gameObject.tag == "Player" || hitPoints == 0){
			Instantiate( onDeathBullet, _transform.position, Quaternion.LookRotation(Vector3.forward, _target.transform.position - _transform.position) ); 
			
			Destroy( gameObject );
			
			Debug.Log (collider.transform.position);
		}
	}
	
	public void RandomSpray( float angle ){
		if( Time.time > nextShotInSpray ){
					
					Instantiate( enemyBullet, _transform.position, Quaternion.Euler( 0, 0, Random.Range( -angle, angle ) + 180 ) );
					
					nextShotInSpray += sprayCD;
					nextShotInSpray = Time.time + sprayCD;
					++counter;
				}
//				if( counter < bulletCount )
//					return;
//			counter = 0;
	}
	
	public void triShot( ){
		if( Time.time > nextShotInSpray ){
			Instantiate( enemyBullet, _transform.position, Quaternion.Euler( 0, 0, 180 ) );
			Instantiate( enemyBullet, _transform.position, Quaternion.Euler( 0, 0, -45 + 180 ) );
			Instantiate( enemyBullet, _transform.position, Quaternion.Euler( 0, 0, 45 + 180 ) );
			
			nextShotInSpray += sprayCD;
			nextShotInSpray = Time.time + sprayCD;
			++counter;
		}
	}
}

//Random Spray

using UnityEngine;
using System.Collections;

public class frozenOrb : Enemy {
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
		bulletCount = Random.Range( 4, 15 );
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		_transform.position += Vector3.down*(speed*Time.deltaTime);
		
		if( Time.time > nextShot ){
			Instantiate( enemyBullet, _transform.position, Quaternion.Euler( 0, 0, Random.Range( -angle, angle ) ) );
			++counter;
			if( counter >= bulletCount ){
				Instantiate( onDeathBullet, _transform.position, Quaternion.LookRotation(Vector3.forward, _target.transform.position - _transform.position) );
				Destroy( gameObject );
			}
			nextShot = Time.time + cooldown;
		}
		
		if( _transform.position.y < -115.0f || Mathf.Abs( _transform.position.x ) > 200.0f ) {
			Destroy( gameObject );
		}
	}
	
	void OnTriggerEnter( Collider collider ){
		if( hitPoints == 0 ){
			Instantiate( onDeathBullet, _transform.position, Quaternion.identity ); 
			
			Destroy( gameObject );
			
			Debug.Log (collider.transform.position);
		}
		else if( collider.gameObject.tag == "Player" ){
			--hitPoints;
		}
	}
}

//Infinite Loop starting at line 31
//Because time doesn't update in the while loop

using UnityEngine;
using System.Collections;

public class Enemy1 : Enemy {
	Transform _transform;
	public int bulletCount;
	float sprayCD;
	public float nextShotInSpray;
	int counter;
//	Quaternion _rotation;
	
	// Use this for initialization
	void Start () {
		_transform = transform;
//		_rotation = transform.rotation;
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
//			for( int i = 0; i < bulletCount; ++i ){
			while( counter < bulletCount ){
//				Instantiate( enemyBullet, _transform.position, _transform.rotation );
				nextShotInSpray = Time.time + sprayCD;
				if( Time.time > nextShotInSpray ){
					_transform.Rotate( new Vector3( 0, 0, Random.Range( -30, 30 ) ) );
					Instantiate( enemyBullet, _transform.position, _transform.rotation );
					
//					_transform.rotation = _rotation;
					nextShotInSpray += sprayCD;
					++counter;
				}
//				_transform.Rotate( new Vector3( 0, 0, 360/bulletCount ) );
			}
			counter = 0;
//			_transform.Rotate( new Vector3( 0, 0, 30 ) );
			nextShot = Time.time + cooldown;
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
}

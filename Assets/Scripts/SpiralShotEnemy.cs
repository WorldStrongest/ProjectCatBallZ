using UnityEngine;
using System.Collections;

public class SpiralShotEnemy : Enemy {
	Transform _transform;
	public int bulletCount;
	
	// Use this for initialization
	void Start () {
		_transform = transform;
		nextShot = cooldown;
		Target ( "Player" );
	}
	
	// Update is called once per frame
	void Update () {
		_transform.position += Vector3.down*(speed*Time.deltaTime);
		
		if( Time.time > nextShot ){
			for( int i = 0; i < bulletCount; ++i ){
				Instantiate( enemyBullet, _transform.position, _transform.rotation );
				_transform.Rotate( new Vector3( 0, 0, 360/bulletCount ) );
			}
//			_go.GetComponent<Bullet>().cooldown
			_transform.Rotate( new Vector3( 0, 0, 30 ) );
			nextShot = Time.time + cooldown;
		}
		
		if( _transform.position.y < -115.0f || Mathf.Abs( _transform.position.x ) > 200.0f ) {
			Destroy( gameObject );
		}
		//
		//_transform.rotation = Quaternion.Lerp (_transform.rotation, Quaternion.LookRotation(Target.position - _transform.position), 100f*Time.deltaTime );
	}
	
	void OnTriggerEnter( Collider collider ){
		if( collider.gameObject.tag == "Player" || hitPoints == 0){
			Instantiate( onDeathBullet, _transform.position, Quaternion.LookRotation(Vector3.forward, _target.transform.position - _transform.position) ); 
			
			Destroy( gameObject );
			
			Debug.Log (collider.transform.position);
		}
	}
}

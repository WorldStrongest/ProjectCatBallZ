using UnityEngine;
using System.Collections;

public class machineGun : Enemy {
	public int bulletCount;
	public int counter;
	
	// Use this for initialization
	void Start () {
		_transform = transform;
		nextShot = cooldown;
		Target ( target );
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		_transform.position += Vector3.down*(speed*Time.deltaTime);
		
		if( Time.time > nextShot ){
			Instantiate( enemyBullet, _transform.position, _transform.rotation );
			++counter;
			nextShot = Time.time + cooldown;
		}
		
		if( counter == bulletCount ){
			Destroy( gameObject );
		}
		
		if( _transform.position.y < -115.0f || Mathf.Abs( _transform.position.x ) > 200.0f ) {
			Destroy( gameObject );
		}
	}
}

using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
	//Add a Weapons Class
	public GameObject bullet;
	float bulletCD;
	float nextShot;
	public int hitPoints;
	public int speed;
	Transform _transform;
	
	// Use this for initialization
	void Start () {
		_transform = transform;
		bulletCD = bullet.GetComponent<Bullet>().cooldown;
		nextShot = bulletCD;
	}
	
	// Update is called once per frame
	void Update () {
//		if( Input.GetAxis( "Horizontal" ) ){
//			_transform.position += ( -speed*Time.deltaTime, 0, 0 );
//		}
		
//		Debug.Log( nextShot);
//			_transform.position += Vector3.right*( Input.GetAxis( "Horizontal" )*speed*Time.deltaTime );
//			_transform.position += Vector3.up*( Input.GetAxis( "Vertical" )*speed*Time.deltaTime );
//			
//			
		float moveX = Mathf.Clamp( _transform.position.x + ( Input.GetAxis( "Horizontal" )*speed*Time.deltaTime ), -125.0f, 125.0f );
		float moveY = Mathf.Clamp( _transform.position.y + ( Input.GetAxis( "Vertical" )*speed*Time.deltaTime ), -93.0f, 93.0f );
			
		_transform.position = new Vector3(moveX, moveY, _transform.position.z);
		
		
		
		if( Input.GetButton( "Fire1" ) && Time.time > nextShot ) {
			Instantiate( bullet, _transform.position, Quaternion.identity );
			nextShot = Time.time + bulletCD;
		}
		
	}
}

public enum bulletName{
	defaultShot
}
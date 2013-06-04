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
		
		Debug.Log( nextShot);
		transform.position += Vector3.right*( Input.GetAxis( "Horizontal" )*speed*Time.deltaTime );
		transform.position += Vector3.up*( Input.GetAxis( "Vertical" )*speed*Time.deltaTime );
		
		if( Input.GetButton( "Fire1" ) && Time.time > nextShot ) {
			Instantiate( bullet, _transform.position, Quaternion.identity );
//			_go.GetComponent<Bullet>().cooldown
			nextShot = Time.time + bulletCD;
		}
		
//	Debug.Log( Input.GetAxis( "Vertical" ) );
	}
}

public enum bulletName{
	defaultShot
}
using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
	//Add a Weapons Class (Maybe not)
	public GameObject bullet;
//	public float timeToFocus;
//	public float focusTime;
	float bulletCD;
	float nextShot;
	public int hitPoints;
	public int speed;
	public int baseSpeed;
	public int focusSpeed;
	Transform _transform;
	
	// Use this for initialization
	void Start () {
		_transform = transform;
		
		speed = baseSpeed;
		focusSpeed = baseSpeed/2;
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
			Instantiate( bullet, new Vector3(_transform.position.x - 5, _transform.position.y - 3, _transform.position.z), Quaternion.identity );
			Instantiate( bullet, new Vector3(_transform.position.x + 5, _transform.position.y - 3, _transform.position.z), Quaternion.identity );
			nextShot = Time.time + bulletCD;
			
//Was used for holding down fire to focus
//			focusTime -= Time.deltaTime;
//			if( focusTime <= 0 ){
//				speed = focusSpeed;
//			}
		}
		
		if( Input.GetButton( "Focus" ) ){
			speed = focusSpeed;
		}
		
		if( Input.GetButtonUp( "Focus" ) ){
			speed = baseSpeed;
		}

//Was used for holding down fire to focus
//		if( Input.GetButtonUp( "Fire1" ) ){
//			focusTime = timeToFocus;
//			speed = baseSpeed;
//		}
		
	}

}


public enum bulletName{
	defaultShot
}
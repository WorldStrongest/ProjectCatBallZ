using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
	//Add a Weapons Class
	public int hitPoints;
	public int speed;
	Transform _transform;
	
	// Use this for initialization
	void Start () {
		_transform = transform;
	}
	
	// Update is called once per frame
	void Update () {
//		if( Input.GetAxis( "Horizontal" ) ){
//			_transform.position += ( -speed*Time.deltaTime, 0, 0 );
//		}
		transform.position += Vector3.right*( Input.GetAxis( "Horizontal" )*speed*Time.deltaTime );
		transform.position += Vector3.up*( Input.GetAxis( "Vertical" )*speed*Time.deltaTime );
//	Debug.Log( Input.GetAxis( "Vertical" ) );
	}
}

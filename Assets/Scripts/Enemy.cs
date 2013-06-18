using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject onDeathBullet;
	public GameObject enemyBullet;
	public Transform _transform;
	public int hitPoints;
	public int speed;
	public int type;
	public float cooldown;
	public float nextShot;
	public Transform _target;
	
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
			Instantiate( enemyBullet, _transform.position, Quaternion.LookRotation(Vector3.forward, _target.position - _transform.position) );
//			_go.GetComponent<Bullet>().cooldown
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
	
	protected void Target( string unitTarget ) {
		if( _target == null ){
			_target = GameObject.FindGameObjectWithTag( unitTarget ).transform;
		}
	}
}

enum enemyType{
	basic,
	spiral
}
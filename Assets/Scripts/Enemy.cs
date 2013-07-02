using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
	public GameObject onDeathBullet;
	public GameObject enemyBullet;
	public Transform _transform;
	public Vector3[] nodes;
	public Color pathColor = Color.cyan;
	public string easeType;
	public int hitPoints;
	public int speed;
	public float cooldown;
	public float nextShot;
	public Transform _target;
	public string target;
	
	// Use this for initialization
	void Start () {
		_transform = transform;
		nextShot = cooldown;
		
		SetEnemyPath( nodes, easeType );
		if( target.Length != 0 )
			Target ( target );
	}
	
	void OnDrawGizmosSelected(){
		if (nodes.Length > 0) {
			iTween.DrawPath(nodes, pathColor);
		}
	}
	
	
	// Update is called once per frame
	void Update () {
//		_transform.position += Vector3.down*(speed*Time.deltaTime);
		
		if( Time.time > nextShot ){
			if( _target != null )
				Instantiate( enemyBullet, _transform.position, Quaternion.LookRotation(Vector3.forward, _target.position - _transform.position) );
			else
				Instantiate( enemyBullet, _transform.position, _transform.rotation );
//			_go.GetComponent<Bullet>().cooldown
			nextShot = Time.time + cooldown;
		}
		
		if( _transform.position.y < -250.0f || Mathf.Abs( _transform.position.x ) > 250.0f ) {
			Destroy( gameObject );
		}
		//
		//_transform.rotation = Quaternion.Lerp (_transform.rotation, Quaternion.LookRotation(Target.position - _transform.position), 100f*Time.deltaTime );
	}
	
	void OnTriggerEnter( Collider collider ){
		if( collider.gameObject.tag == "Player" || hitPoints == 0){
			hitPoints--;
		}
		if( hitPoints == 0 ){
			Destroy( gameObject );
			if( _target != null )
				Instantiate( onDeathBullet, _transform.position, Quaternion.LookRotation(Vector3.forward, _target.transform.position - _transform.position) ); 
			else
				Instantiate( onDeathBullet, _transform.position, _transform.rotation ); 
		}
	}
	
	protected void Target( string unitTarget ) {
		if( _target == null ){
			_target = GameObject.FindGameObjectWithTag( unitTarget ).transform;
		}
	}
	
	public void SetEnemyPath( Vector3[] enemyPath, string easeType ) {
		if (easeType == string.Empty)
			easeType = "linear";
		
		// move enemy along the path
		iTween.MoveTo(gameObject, iTween.Hash(
			"path", enemyPath,
			"speed", speed*2,
			"easeType", easeType,
			"islocal", true,
			"movetopath", false,
			"oncomplete", "DestroySelf"));
	}
	
	void DestroySelf() {
		Destroy( gameObject );
	}
}
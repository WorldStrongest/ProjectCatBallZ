using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
	public GameObject onDeathBullet;
	public GameObject enemyBullet;
	public Transform _transform;
	public Vector3[] nodes;
	public Color pathColor = Color.cyan;
	public iTween.EaseType easeType;
	public iTween.LoopType loopType;
	public bool moveToPath;
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
		
		SetEnemyPath( nodes, easeType, loopType );
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
	
//	void OnTriggerEnter( Collider collider ){
//		if( collider.gameObject.tag == "Player" ){
//			hitPoints--;
//		}
//		if( hitPoints == 0 ){
//			Destroy( gameObject );
//			if( _target != null )
//				Instantiate( onDeathBullet, _transform.position, Quaternion.LookRotation(Vector3.forward, _target.transform.position - _transform.position) ); 
//			else
//				Instantiate( onDeathBullet, _transform.position, _transform.rotation ); 
//		}
//	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Bullet")) // hit by a bullet
		{	
			TakeDamage(1); // take away 1 hit point
			 
		    // disable the bullet and put it back on its stack
			other.gameObject.SetActive(false);
		    GameMaster.playerBulletStack.Push(other.gameObject);
		}
	}

	public void TakeDamage(int damage)
	{
		// subtract damage and check if it's dead
		hitPoints -= damage;
		if (hitPoints <= 0)
			Explode();
	}

	public void Explode() // destroy this enemy
	{
		// draw particle explosion effect
		// play sound
		Destroy(this.gameObject);
		
		// increment the score
//		GameMaster.score++;
	}
	
	protected void Target( string unitTarget ) {
		if( _target == null ){
			_target = GameObject.FindGameObjectWithTag( unitTarget ).transform;
		}
	}
	
	public void SetEnemyPath( Vector3[] enemyPath, iTween.EaseType easeType, iTween.LoopType loopType ) {
		iTween.Stop( gameObject );
		
		
		// move enemy along the path
		if( loopType == 0 )
		iTween.MoveTo(gameObject, iTween.Hash(
			"path", enemyPath,
			"speed", speed*2,
			"easeType", easeType,
			"islocal", true,
			"movetopath", moveToPath,
			"looptype", loopType,
			"oncomplete", "DestroySelf"));
		else
			iTween.MoveTo(gameObject, iTween.Hash(
			"path", enemyPath,
			"speed", speed*2,
			"easeType", easeType,
			"islocal", true,
			"movetopath", moveToPath,
			"looptype", loopType));
	}
	
	public void Damage(int amount)
	{
		hitPoints -= amount;
		if (hitPoints <= 0) {
			Destroy( gameObject );
		}
	}
	
	void DestroySelf() {
		Destroy( gameObject );
	}
}
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Transform _transform;
	public float cooldown;
	public int bulletSpeed;
	public int damage;
	public int pierceCount;
	public bool enemyBullet;
//	string TAG;
	
	// Use this for initialization
	void Start () {
//		TAG = gameObject.tag;
		_transform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		_transform.position += _transform.up*(bulletSpeed*Time.deltaTime);
		if( Mathf.Abs( _transform.position.y ) > 115.0f || Mathf.Abs( _transform.position.x ) > 200.0f ) {
			Destroy( gameObject );
		}
		
	}
	
	void OnTriggerEnter( Collider collider ) {
		//Collision with Enemy/Player/Wall
		Debug.Log(collider.tag);
		if( !enemyBullet && collider.gameObject.tag == "Enemy" ) {
			Destroy( gameObject );
			Enemy enemy = collider.gameObject.GetComponent<Enemy>();
			if (enemy == null) {
				collider.transform.parent.GetComponent<Enemy>();
			}
			
			enemy.hitPoints--;
		}
		else if( enemyBullet && collider.gameObject.tag == "Player" ){
			Destroy( gameObject );
			collider.gameObject.GetComponent<Player>().hitPoints--;
		}
		
	}
}

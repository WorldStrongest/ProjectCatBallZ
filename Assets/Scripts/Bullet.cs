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
		if( _transform.position.y > 115.0f ) {
			Destroy( gameObject );
		}
		
	}
	
	void OnTriggerEnter( Collider collider ) {
		//Collision with Enemy/Player/Wall
		if( !enemyBullet && collider.gameObject.tag == "Enemy" ) {
			Destroy( gameObject );
			collider.gameObject.GetComponent<Enemy>().hitPoints--;
		}
		else if( enemyBullet && collider.gameObject.tag == "Player" ){
			Destroy( gameObject );
			collider.gameObject.GetComponent<Player>().hitPoints--;
		}
		
	}
}

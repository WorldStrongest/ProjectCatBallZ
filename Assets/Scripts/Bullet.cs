using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Transform _transform;
//	public float cooldown;
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
		
//		_transform.position += motion*Time.deltaTime;
		_transform.position += _transform.up*(bulletSpeed*Time.deltaTime);
//		if( Mathf.Abs( _transform.position.y ) > 115.0f || Mathf.Abs( _transform.position.x ) > 200.0f ) {
//			Destroy( gameObject );
//		}
		
	}
	
//	void OnTriggerEnter( Collider collider ) {
//		//Collision with Enemy/Player/Wall
////		Debug.Log(collider.tag);
//		if( !enemyBullet && collider.gameObject.tag == "Enemy" ) {
//			Destroy( gameObject );
//			Enemy enemy;
//			enemy = collider.gameObject.GetComponent<Enemy>();
//			if (enemy == null) {
//				enemy = collider.transform.parent.gameObject.GetComponent<Enemy>();
//			}
////			transform.parent.gameObject.GetComponent<Enemy>();
//			enemy.Damage(1);
//		}
//		else if( enemyBullet && collider.gameObject.tag == "Player" ){
//			Destroy( gameObject );
//			Player player;
//			player = collider.gameObject.GetComponent<Player>();
//			if( player == null ){
//				player = collider.transform.parent.gameObject.GetComponent<Player>();
//			}
//			player.Damage(1);
//		}
//		
//	}
}

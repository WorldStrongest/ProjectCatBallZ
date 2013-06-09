using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject bullet;
	Transform _transform;
	public int hitPoints;
	public int speed;
	public int cooldown;
	public Transform Target;
	
	// Use this for initialization
	void Start () {
		_transform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		_transform.position += Vector3.down*(speed*Time.deltaTime);
		
		//_transform.rotation = Quaternion.Lerp (_transform.rotation, Quaternion.LookRotation(Target.position - _transform.position), 100f*Time.deltaTime );
	}
	
	void OnTriggerEnter( Collider collider ){
		if( collider.gameObject.tag == "Player" ){
			Instantiate( bullet, _transform.position, Quaternion.LookRotation(Vector3.forward, collider.transform.position - _transform.position) ); 
			
			Destroy( gameObject );
		}
	}
}

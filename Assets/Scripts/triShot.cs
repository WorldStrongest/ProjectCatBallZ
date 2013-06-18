//Tri Shot
using UnityEngine;
using System.Collections;

public class triShot : MonoBehaviour {
	Bullet[] bullet;
	// Use this for initialization
	void Start () {
		bullet = GetComponentsInChildren<Bullet>();
	}
	
	// Update is called once per frame
	void Update () {
		if( bullet[0] == null && bullet[1] == null && bullet[2] == null )
			Destroy( gameObject );
	}
}

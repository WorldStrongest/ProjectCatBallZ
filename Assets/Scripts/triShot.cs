//Tri Shot
using UnityEngine;
using System.Collections;

public class triShot : MonoBehaviour {
	Bullet[] bullet;
	int totalChilds;
	bool emptyObject;
	// Use this for initialization
	void Start () {
		bullet = GetComponentsInChildren<Bullet>();
		totalChilds = bullet.Length;
	}
	
	// Update is called once per frame
	void Update () {
//		if( bullet[0] == null && bullet[1] == null && bullet[2] == null )
//			Destroy( gameObject );
		
		for( int i = 0; i < totalChilds; ++i ){
		if( bullet[i] != null )
			{
				emptyObject = false;
				break;
			}
			emptyObject = true;
		}
		if( emptyObject )
			Destroy( gameObject );
	}
}

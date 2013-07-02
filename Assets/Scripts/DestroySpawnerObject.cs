using UnityEngine;
using System.Collections;

public class DestroySpawnerObject : MonoBehaviour {
	Enemy[] enemy;
	int totalChilds;
	bool emptyObject;
	// Use this for initialization
	void Start () {
		enemy = GetComponentsInChildren<Enemy>();
		totalChilds = enemy.Length;
		emptyObject = false;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ( totalChilds );
//		if( bullet[0] == null && bullet[1] == null && bullet[2] == null )
//			Destroy( gameObject );
		for( int i = 0; i < totalChilds; ++i ){
			if( enemy[i] != null )
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

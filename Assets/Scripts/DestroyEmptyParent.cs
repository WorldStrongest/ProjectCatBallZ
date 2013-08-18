using UnityEngine;
using System.Collections;

public class DestroyEmptyParent : MonoBehaviour {
	Transform[] children;
	int totalChilds;
	int nullCount;
	
	// Use this for initialization
	void Start () {
		children = GetComponentsInChildren<Transform>();
		totalChilds = children.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
		nullCount = 0;
		
		for( int i = 0; i < totalChilds && nullCount <= 1; ++i ){
			if( children[i] != null )
			{
				nullCount++;
			}
		}
		
		if ( nullCount == 1) {
			Destroy( gameObject );
		}
	}
}

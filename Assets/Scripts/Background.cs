using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	
	public Transform[] _bgs;
	public int speed;
	float amtToMove;
	
	// Update is called once per frame
	void Update () {
		amtToMove = speed*Time.deltaTime;
		_bgs[0].position += Vector3.down*amtToMove;
		_bgs[1].position += Vector3.down*amtToMove;
		
		if (_bgs[0].position.y <= -500.0f) // bg's size is 500
		{
			_bgs[0].position += Vector3.up*1000.0f; // move bg behind the other bg
		}
		
		else if (_bgs[1].position.y <= -500.0f)
		{
			_bgs[1].position += Vector3.up*1000.0f;
		}
	}
}

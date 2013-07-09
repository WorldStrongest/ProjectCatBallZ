using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	
	public Transform[] _bgs;
	public int speed;
	float yScale;
	float amtToMove;
	
	void Start() {
		yScale = _bgs[0].localScale.y;
	}
	// Update is called once per frame
	void Update () {
		amtToMove = speed*Time.deltaTime;
		_bgs[0].position += Vector3.down*amtToMove;
		_bgs[1].position += Vector3.down*amtToMove;
		
		if (_bgs[0].localPosition.y <= -yScale) // bg's size is yScale
		{
			_bgs[0].position += Vector3.up*yScale*2; // move bg behind the other bg
		}
		
		else if (_bgs[1].localPosition.y <= -yScale)
		{
			_bgs[1].position += Vector3.up*yScale*2;
		}
	}
}

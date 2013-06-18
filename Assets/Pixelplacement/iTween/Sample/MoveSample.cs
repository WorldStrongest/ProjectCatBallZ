using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	void Start(){
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("uno"), "easeType", "easeInOutSine", "loopType", "pingPong", "delay", .1, "time", 5));
		iTween.RotateBy(gameObject, iTween.Hash("x", .75, "easeType", "linear", "loopType", "loop", "delay", 0));
	}
}


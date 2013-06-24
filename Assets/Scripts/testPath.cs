using UnityEngine;
using System.Collections;

public class testPath : MonoBehaviour {
	public float enemySpeed;
	public string firstPath;
	public string secondPath;
	// Use this for initialization
	void Start () {
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (firstPath), "easeType", "linear", "speed", enemySpeed, "onComplete", "startSecondPath"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void startSecondPath()
	{
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (secondPath), "easeType", "linear", "speed", enemySpeed));
	}
}

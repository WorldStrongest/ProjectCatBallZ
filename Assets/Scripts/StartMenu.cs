using UnityEngine;
using System.Collections;



public class StartMenu : MonoBehaviour {
	private int height = Screen.height;
	private int width = Screen.width;
	// Use this for initialization
	void Start () {
	}
	
	void OnGUI(){
		GUI.backgroundColor = Color.green;
		GUI.Button( new Rect( width/2 - 70, height/2 - 30, 70, 30 ), "A Button" );
		PlayerPrefs.Save( );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void titleMenu( ){
		GUI.backgroundColor = Color.blue;
//		GUI.Button ( );
	}
}
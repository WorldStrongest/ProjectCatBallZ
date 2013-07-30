using UnityEngine;
using System.Collections;

public class PlayerFlyIn : MonoBehaviour {
	
	public Vector3[] nodes;
	public Color pathColor = Color.cyan;
	public int speed;
	public iTween.EaseType easeType;
	public iTween.LoopType loopType;
	public bool moveToPath;
	
	Player _player;
	
	void OnDrawGizmosSelected(){
		if (nodes.Length > 0) {
			iTween.DrawPath(nodes, pathColor);
		}
	}
	// Use this for initialization
	void Start () {
		_player = GetComponent<Player>();
		_player.enabled = false;		// Disable player control
					
		// Moves player along nodes path
		iTween.MoveTo(gameObject, iTween.Hash(
			"path", nodes,
			"speed", speed*2,
			"easeType", easeType,
			"islocal", true,
			"movetopath", moveToPath,
			"looptype", loopType,
			"oncomplete", "EnableControl"));
		
		// Rotates player among y axis
		iTween.RotateBy(gameObject, iTween.Hash (
			"y", -20.0f)
		);
	}
	
	// Enables the player's control
	void EnableControl() {
		_player.enabled = true;
	}
}

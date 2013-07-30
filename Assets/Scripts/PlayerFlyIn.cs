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
	Transform _transform;
	
	void OnDrawGizmosSelected(){
		if (nodes.Length > 0) {
			iTween.DrawPath(nodes, pathColor);
		}
	}
	// Use this for initialization
	void Start () {
		_player = GetComponent<Player>();
		_transform = transform;
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
			"y", -15.0f)
		);
	}
	
	// Enables the player's control
	void EnableControl() {
		iTween.Stop(gameObject);
		_transform.rotation = Quaternion.identity;
		_player.enabled = true;
		Destroy(GetComponent<PlayerFlyIn>());
	}
}

using UnityEngine;
using System.Collections;

public class phaseHandler : MonoBehaviour {
	Enemy4[] phases;
	int totalPhases;
	int phaseIterator;
	public int endPhase1;
	public int endPhase2;
	
	// Use this for initialization
	void Start () {
		phases = GetComponents<Enemy4>();
		totalPhases = phases.Length;
//		Debug.Log( totalPhases );
	}
	
	// Update is called once per frame
	void Update () {
		if( phases[0].hitPoints < endPhase2 ){
			phases[1].enabled = false;
			phases[2].enabled = true;
		}
		else if( phases[0].hitPoints < endPhase1 ){
			phases[0].enabled = false;
			phases[1].enabled = true;
		}
		
	}
}

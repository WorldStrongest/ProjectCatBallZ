
using UnityEngine;
using System.Collections;

[System.Serializable]
public class phaseData
{
	public enemyData[] enemyDATA;
	public Vector3[] NODES;
};

public class Boss: Enemy {
///	public enemyData[] enemyDATA;
	public phaseData[] phases;
	public bool suicideOnComplete;
	int curShot; // The index of the current shot
	int totalShots;	// The total number of shots this enemy has
	public int[] nextPhase;
	int phaseCount;

	// float[] nextBullet;
	// int localCounter
	// int curShot;
	// 

	void Start() {
		_transform = transform;	// cache this transform
		SetEnemyPath( nodes, easeType, loopType );

		curShot = 0;
		totalShots = phases[phaseCount].enemyDATA.Length;
		nextShot = Time.time + phases[phaseCount].enemyDATA[0].nextCD;
	}
	
	void Update() {
		if ( Time.time > nextShot ) {
			do {
				// get a bullet from the stack
				// need to figure out which stack to pull bullet from based on enemyDATA[curShot].bullet
				//GameObject newBullet = GameMaster.enemyBulletStack.Pop();
				GameObject newBullet = Instantiate ( phases[phaseCount].enemyDATA[curShot].bullet ) as GameObject;
				
				// rotation is different in these
				if ( phases[phaseCount].enemyDATA[curShot].targetFire ) {
					newBullet.transform.rotation = Quaternion.LookRotation( Vector3.forward, _target.position - _transform.position );
				} else if ( phases[phaseCount].enemyDATA[curShot].randomAngle ) {
					newBullet.transform.rotation = Quaternion.Euler( 0, 0, Random.Range( -phases[phaseCount].enemyDATA[curShot].angle, phases[phaseCount].enemyDATA[curShot].angle ) + 180 );
				} else if ( phases[phaseCount].enemyDATA[curShot].angle != 0 ) {
					newBullet.transform.rotation = Quaternion.Euler( 0, 0, phases[phaseCount].enemyDATA[curShot].angle + 180 );
				} else {
					newBullet.transform.rotation = Quaternion.Euler( _transform.rotation.x, _transform.rotation.y, _transform.rotation.z + 180 ) ;
				}

				// position and enable it
				newBullet.transform.position =  _transform.position + new Vector3( phases[phaseCount].enemyDATA[curShot].displacementX, phases[phaseCount].enemyDATA[curShot].displacementY, 0);
				newBullet.SetActive(true);

				++curShot;
				if (curShot >= totalShots) {
					if (suicideOnComplete)
						Explode();
					else {
						curShot = 0;
						nextShot = Time.time + cooldown;
					}
				} else {
					nextShot = Time.time + phases[phaseCount].enemyDATA[curShot].nextCD;
				}
			} while (phases[phaseCount].enemyDATA[curShot].nextCD == 0 && totalShots > 1);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Bullet") || other.CompareTag("Bullet2")) // hit by a bullet
		{	
			TakeDamage(1); // take away 1 hit point
			 
		    // disable the bullet and put it back on its stack
			other.gameObject.SetActive(false);
			if (other.CompareTag("Bullet"))
		    	GameMaster.playerBulletStack.Push(other.gameObject);
			else
		    	GameMaster.playerBulletStack2.Push(other.gameObject);
		}
		if( hitPoints < nextPhase[1] && phaseCount == 1 ){
			++phaseCount;
			SetNewPath();
			SetEnemyPath( nodes, easeType, loopType );
		}
		else if( hitPoints < nextPhase[0] && phaseCount == 0 ){
			++phaseCount;
			SetNewPath();
			SetEnemyPath( nodes, easeType, loopType );
		}
	}
	
	public void SetNewPath( ){
		nodes = phases[phaseCount].NODES;
	}
	
	new public void SetEnemyPath( Vector3[] enemyPath, iTween.EaseType easeType, iTween.LoopType loopType ) {
		iTween.Stop( gameObject );	// stops any running iTween
			
		// move enemy along the path
		if( loopType == 0 )	// If not looping, explode at the end of the path
			iTween.MoveTo(gameObject, iTween.Hash(
				"path", enemyPath,
				"speed", speed*2,
				"easeType", easeType,
				"islocal", true,
				"movetopath", moveToPath,
				"looptype", loopType,
				"oncomplete", "SetNewPath"));
		else
			iTween.MoveTo(gameObject, iTween.Hash(
				"path", enemyPath,
				"speed", speed*2,
				"easeType", easeType,
				"islocal", true,
				"movetopath", moveToPath,
				"looptype", loopType));
	}
}
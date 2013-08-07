
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
	public int phaseCount;
	
	bool firstShot;
	float[] nextBullet;
	// int localCounter
	// int curShot;
	// 

	void Start () {
		_transform = transform;

 		SetEnemyPath( nodes, easeType, loopType );
 		totalShots = phases[phaseCount].enemyDATA.Length;
		nextShot = cooldown;
		nextBullet = new float[totalShots];
		firstShot = true;
		Target( target );
		
		for( int i = 0; i < totalShots; ++i ){
			nextBullet[i] = phases[phaseCount].enemyDATA[i].nextCD;
			phases[phaseCount].enemyDATA[i].shotFired = false;
		}	
 	}
	
	void Update () {
//		_transform.position += Vector3.down*(speed*Time.deltaTime);
		
		if( Time.time > nextShot ){
			if( firstShot ){
				firstShot = false;
				nextBullet[0] = Time.time + phases[phaseCount].enemyDATA[0].nextCD;
				phases[phaseCount].enemyDATA[0].shotFired = false;
				curShot = 0;
				for( int i = 1; i < totalShots; ++i ){
					nextBullet[i] = nextBullet[i-1] + phases[phaseCount].enemyDATA[i].nextCD;
					phases[phaseCount].enemyDATA[i].shotFired = false;
				}
			}


		
 
			for( int i = 0; i <totalShots; ++i ){
				if( !phases[phaseCount].enemyDATA[i].shotFired && Time.time > nextBullet[i] ){
					if( phases[phaseCount].enemyDATA[i].targetFire )
						Instantiate( phases[phaseCount].enemyDATA[i].bullet, new Vector3( _transform.position.x + phases[phaseCount].enemyDATA[i].displacementX, _transform.position.y + phases[phaseCount].enemyDATA[i].displacementY, 0 ), Quaternion.LookRotation( Vector3.forward, _target.position - _transform.position ) );
					else if( phases[phaseCount].enemyDATA[i].randomAngle )
						Instantiate( phases[phaseCount].enemyDATA[i].bullet, new Vector3( _transform.position.x + phases[phaseCount].enemyDATA[i].displacementX, _transform.position.y + phases[phaseCount].enemyDATA[i].displacementY, 0 ), Quaternion.Euler( 0, 0, Random.Range( -phases[phaseCount].enemyDATA[i].angle, phases[phaseCount].enemyDATA[i].angle ) + 180 ) );
					else if( phases[phaseCount].enemyDATA[i].angle != 0 )
						Instantiate( phases[phaseCount].enemyDATA[i].bullet, new Vector3( _transform.position.x + phases[phaseCount].enemyDATA[i].displacementX, _transform.position.y + phases[phaseCount].enemyDATA[i].displacementY, 0 ), Quaternion.Euler( 0, 0, phases[phaseCount].enemyDATA[i].angle + 180 ) );
					else
						Instantiate( phases[phaseCount].enemyDATA[i].bullet, new Vector3( _transform.position.x + phases[phaseCount].enemyDATA[i].displacementX, _transform.position.y + phases[phaseCount].enemyDATA[i].displacementY, 0 ), Quaternion.Euler( _transform.rotation.x, _transform.rotation.y, _transform.rotation.z + 180 ) );
					phases[phaseCount].enemyDATA[i].shotFired = true;
					
					if( i == totalShots - 1 ){
						if( suicideOnComplete ){
							Destroy( gameObject );
						}
						firstShot = true;
						phases[phaseCount].enemyDATA[totalShots - 1].shotFired = true;
//					break;
					}
 				}
			}
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
//		if( hitPoints < nextPhase[1] && phaseCount == 1 ){
//			++phaseCount;
//			SetNewPath();
//			SetEnemyPath( nodes, easeType, loopType );
//		}
//		else if( hitPoints < nextPhase[0] && phaseCount == 0 ){
//			++phaseCount;
//			SetNewPath();
//			SetEnemyPath( nodes, easeType, loopType );
//		}
		if( hitPoints < nextPhase[0] && phaseCount == 0 ){
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
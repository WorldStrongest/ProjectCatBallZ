
// Enemy 4 mod
using UnityEngine;
using System.Collections;

[System.Serializable]
public class enemyData{
	public GameObject bullet;
	public float nextCD;
	public float angle;
	public float displacementX;
 	public float displacementY;
 	public int loopCount;
 	public bool targetFire;
 	public bool randomAngle;
};

public class Enemy4: Enemy {
	public enemyData[] enemyDATA;
	public bool suicideOnComplete;
	int curShot; // The index of the current shot
	int totalShots;	// The total number of shots this enemy has

	// float[] nextBullet;
	// int localCounter
	// int curShot;
	// 

	void Start() {
		_transform = transform;	// cache this transform
		SetEnemyPath( nodes, easeType, loopType );
		
		if( target.Length != 0 )
			Target ( target );
		
		curShot = 0;
		totalShots = enemyDATA.Length;
		nextShot = Time.time + enemyDATA[0].nextCD;
	}

	void Update() {
		if ( Time.time > nextShot ) {
			do {
				// get a bullet from the stack
				// need to figure out which stack to pull bullet from based on enemyDATA[curShot].bullet
				//GameObject newBullet = GameMaster.enemyBulletStack.Pop();
				GameObject newBullet = Instantiate ( enemyDATA[curShot].bullet ) as GameObject;
				
				// rotation is different in these
				if ( enemyDATA[curShot].targetFire ) {
					newBullet.transform.rotation = Quaternion.LookRotation( Vector3.forward, _target.position - _transform.position );
				} else if ( enemyDATA[curShot].randomAngle ) {
					newBullet.transform.rotation = Quaternion.Euler( 0, 0, Random.Range( -enemyDATA[curShot].angle, enemyDATA[curShot].angle ) + 180 );
				} else if ( enemyDATA[curShot].angle != 0 ) {
					newBullet.transform.rotation = Quaternion.Euler( 0, 0, enemyDATA[curShot].angle + 180 );
				} else {
					newBullet.transform.rotation = Quaternion.Euler( _transform.rotation.x, _transform.rotation.y, _transform.rotation.z + 180 ) ;
				}

				// position and enable it
				newBullet.transform.position =  _transform.position + new Vector3( enemyDATA[curShot].displacementX, enemyDATA[curShot].displacementY, 0);
				newBullet.SetActive(true);

				++curShot;
				if (curShot >= totalShots) {
					if (suicideOnComplete) {
						Explode();
					} else {
						curShot = 0;
					}
				}
				nextShot = Time.time + enemyDATA[curShot].nextCD;
			} while (enemyDATA[curShot].nextCD == 0 && totalShots > 1);
		}
	}
}
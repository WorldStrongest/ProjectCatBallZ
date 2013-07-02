using UnityEngine;
using System.Collections;

// Enabling Linq
using System.Collections.Generic; //Always a good idea
using System.Linq;

[ExecuteInEditMode] // enables execution of script in edit mode
public class MasterSpawner : MonoBehaviour {
	
	public SpawnerTimePair[] spawnTable;
	public int spawnedCount;
	
	public float curTime;
	
	private int _tableSize;
	private Transform _transform;
	
	// Use this for initialization
	void Start () {
		_transform = transform;
		_tableSize = spawnTable.Length;
		
//		spawnTable = spawnTable.OrderBy(st => st.spawnTime).ToArray();
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.isPlaying)
		{
			curTime = Time.time;
			
			if ((spawnedCount < _tableSize) && (Time.time >= spawnTable[spawnedCount].spawnTime))
			{
				if( spawnTable[spawnedCount].nodes.Length != 0 ){
					GameObject go = (GameObject)Instantiate(spawnTable[spawnedCount].spawner, _transform.position, _transform.rotation);
//					go.GetComponent<Enemy>().SetEnemyPath(spawnTable[spawnedCount].pathNames);
					go.GetComponent<Enemy>().SetEnemyPath(spawnTable[spawnedCount].nodes, spawnTable[spawnedCount].easeType);
				}
//				else{
//					Debug.Log( spawnedCount );
//					Instantiate( spawnTable[spawnedCount].spawner, new Vector3( spawnTable[spawnedCount].spawnPoint, _transform.position.y, 0 ), _transform.rotation );
//				}
				spawnedCount++;
			} else if (spawnedCount >= _tableSize) {
				Destroy(gameObject);
			}
		}
//			else {
//			// else you're in edit mode. sort table by time
//			spawnTable = spawnTable.OrderBy(st => st.spawnTime).ToArray();
//		}
	}
	
	[System.Serializable]
	public class SpawnerTimePair {
		public GameObject spawner;
		public float spawnTime;
//		public float spawnPoint;
		public Vector3[] nodes;
		public string easeType;
	}
}


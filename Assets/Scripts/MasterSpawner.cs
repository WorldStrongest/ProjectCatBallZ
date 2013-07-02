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
			curTime += Time.deltaTime;
			
			if ((spawnedCount < _tableSize) && (curTime >= spawnTable[spawnedCount].spawnTime))
			{
				GameObject go = (GameObject)Instantiate(spawnTable[spawnedCount].spawner, spawnTable[spawnedCount].spawnPoint , _transform.rotation);
				Enemy enemy = go.GetComponent<Enemy>();
					
//					if (enemy != null) {
//						enemy.SetEnemyPath(spawnTable[spawnedCount].spawnPoint, spawnTable[spawnedCount].easeType);
//					}
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
		public Vector3 spawnPoint;
		public string easeType;
	}
}


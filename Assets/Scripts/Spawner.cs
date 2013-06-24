using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	//Enemy Prefabs
	public GameObject[] enemies;

	public float spawnCooldown; // how often to spawn enemies
	public int enemyIndex; 		// -1 for random enemy
	public int numToSpawn;		// number of enemies this spawnner spawns

	public string[] pathNames;

	private float spawnTimer;
	private int _spawnedCount; 	// the number of enemies that have been spawned
	private Transform _transform;

	// Use this for initialization
	void Start ()
	{
		_transform = transform;
		_spawnedCount = 0;
	}

	// Update is called once per frame
	void Update ()
	{
		if (_spawnedCount >= numToSpawn)
		{
			Destroy(gameObject);
		}
		else if (spawnTimer >= spawnCooldown)
		{
			spawnEnemy(enemyIndex);
			spawnTimer = 0;
		}
		else
		{
			spawnTimer += Time.deltaTime;
		}
	}

	private void spawnEnemy(int i)
	{
		// if i is -1, spawn random enemy
		if (i == -1)
		{
			i = Random.Range(0,enemies.Length);
		}

		GameObject go = (GameObject)Instantiate(enemies[i], _transform.position, _transform.rotation); // spawn enemy
		go.GetComponent<Enemy>().SetEnemyPath(pathNames);
		_spawnedCount++;
	}
}
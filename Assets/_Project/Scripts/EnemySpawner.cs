using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	public Enemy[] enemyPrefabs;
	public Enemy bossPrefab;
	public Transform[] spawnPoints;
	public float spawnRate = 1f;
	public int spawnCount = 10;

	private IEnumerator SpawnEnemy()
	{
		while (spawnCount-- > 0)
		{
			Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
			Enemy enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
			Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity).transform.SetParent(transform);
			yield return new WaitForSeconds(spawnRate);
		}
		
		Instantiate(bossPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity).transform.SetParent(transform);
		
		yield return new WaitForSeconds(5f);
		if (GameManager.Instance.currentWave < GameManager.Instance.maxWave)
		{
			SpawnWave(++GameManager.Instance.currentWave);
		}
		else
		{
			GameManager.Instance.GameOver();
		}
	}
	public void SpawnWave(int currentWave)
	{
		spawnCount = 10 + (currentWave * 3);
		StartCoroutine(SpawnEnemy());
	}
}

using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	public Enemy enemyPrefab;
	public Transform[] spawnPoints;
	public float spawnRate = 1f;
	public int spawnCount = 10;

	private void Update()
	{
		print(Random.Range(0, spawnPoints.Length));
	}

	private IEnumerator SpawnEnemy()
	{
		while (spawnCount-- > 0)
		{
			Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
			Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity).transform.SetParent(transform);
			yield return new WaitForSeconds(spawnRate);
		}
		
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

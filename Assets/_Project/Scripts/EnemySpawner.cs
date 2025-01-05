using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	public Enemy[] enemyPrefabs;
	public Enemy bossPrefab;
	public Transform[] spawnPoints;
	public float spawnRate = 1f;
	public int spawnCount = 10;

	public List<Enemy> enemies = new List<Enemy>();
	
	private IEnumerator SpawnEnemy()
	{
		while (spawnCount-- > 0 && !GameManager.Instance.isGameOver)
		{
			Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
			Enemy enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
			Enemy newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
			newEnemy.enemySpawner = this;
			enemies.Add(newEnemy);
			newEnemy.transform.SetParent(transform);
			yield return new WaitForSeconds(spawnRate);
		}

		int bossSpawnCount = 1 + (GameManager.Instance.currentWave / 2);
		while (bossSpawnCount-- > 0)
		{ 
			yield return new WaitForSeconds(spawnRate);

			Enemy newBoss = Instantiate(bossPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
			newBoss.enemySpawner = this;
			enemies.Add(newBoss);
		}
		
		yield return new WaitUntil(() => enemies.Count == 0);
		if (GameManager.Instance.currentWave < GameManager.Instance.maxWave)
		{
			SpawnWave(++GameManager.Instance.currentWave);
		}
		else
		{
			GameManager.Instance.Win();
		}
	}
	public void SpawnWave(int currentWave)
	{
		if (GameManager.Instance.isGameOver)
			return;
		spawnCount = 10 + (currentWave * 5);
		StartCoroutine(SpawnEnemy());
	}
}

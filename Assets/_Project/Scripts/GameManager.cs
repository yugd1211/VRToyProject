using UnityEngine;

public partial class GameManager : MonoBehaviour
{
	public BaseCamp baseCamp;
	public int currentWave;
	public int maxWave;
	public int score;
	
	private EnemySpawner _enemySpawner;
	
	private void Start()
	{
		baseCamp.health.OnDeath += GameOver;
		currentWave = 1;
		_enemySpawner = FindObjectOfType<EnemySpawner>();
		_enemySpawner.SpawnWave(currentWave);
	}

	public void GameOver()
	{
		print("Game Over");
	}
}

// singleton
public partial class GameManager
{
	public static GameManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
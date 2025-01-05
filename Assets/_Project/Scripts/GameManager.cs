using UnityEngine;

public partial class GameManager : MonoBehaviour
{
	public BaseCamp baseCamp;
	public int currentWave;
	public int maxWave;
	public int score;
	public bool isGameOver;
	
	private EnemySpawner _enemySpawner;
	public GameObject gameWinObject;
	public GameObject startGameObject;
	public GameObject selectModeObject;
	
	private void Start()
	{
		baseCamp.health.OnDeath += GameOver;
		currentWave = 1;
		_enemySpawner = FindObjectOfType<EnemySpawner>();
	}

	public void GameOver()
	{
		isGameOver = true;
	}
	
	public void Win()
	{
		isGameOver = true;
		gameWinObject.SetActive(true);
		// selectModeObject.SetActive(true);
	}
	
	public void GameStart()
	{
		isGameOver = false;		
		currentWave = 1;
		_enemySpawner.SpawnWave(currentWave);
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
		isGameOver = false;
	}
}

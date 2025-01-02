using UnityEngine;

public partial class GameManager : MonoBehaviour
{
	public GameObject baseCamp;
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

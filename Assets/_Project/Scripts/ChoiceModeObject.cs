using UnityEngine;

public class ChoiceModeObject : MonoBehaviour
{
	public int mode;
	public GameObject selectModeObject;
	private void OnCollisionEnter(Collision other)
	{
		GameManager.Instance.maxWave = mode * 2;
		Destroy(selectModeObject.gameObject);
		GameManager.Instance.startGameObject.SetActive(true);
	}
}

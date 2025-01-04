using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
	public TextMeshProUGUI waveText;
	public TextMeshProUGUI scoreText;

	private void Update()
	{
		waveText.text = $"Wave: {GameManager.Instance.currentWave} / {GameManager.Instance.maxWave}";
		scoreText.text = $"Score: {GameManager.Instance.score}";
	}
}

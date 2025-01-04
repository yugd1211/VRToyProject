using UnityEngine;

public class ScoreObject : MonoBehaviour
{
	private void Start()
	{
		transform.LookAt(Camera.main.transform);
		transform.Rotate(0, 180, 0);
		Destroy(gameObject, 2f);
	}

	private void Update()
	{
		transform.position += Vector3.up * Time.deltaTime;
	}
}

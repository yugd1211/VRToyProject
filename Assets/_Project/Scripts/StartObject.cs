using System;
using UnityEngine;

public class StartObject : MonoBehaviour
{
	private void OnCollisionEnter(Collision other)
	{
		GameManager.Instance.GameStart();
		Destroy(gameObject);
	}

	private void Update()
	{
		transform.position += Vector3.up * Mathf.Sin(Time.time) * Time.deltaTime;
	}
}

using UnityEngine;

public class Projectile : MonoBehaviour
{
	private void OnCollisionEnter(Collision other)
	{
		if (!GameManager.Instance.isGameOver && other.collider.TryGetComponent(out Enemy enemy))
		{
			enemy.TakeDamage(1);
		}
		Destroy(gameObject);
	}
}

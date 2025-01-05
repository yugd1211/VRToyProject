using UnityEngine;

public class Projectile : MonoBehaviour
{
	private void Start()
	{
		// Destroy(gameObject, 5f);
	}
	
	private void OnCollisionEnter(Collision other)
	{
		if (other.collider.TryGetComponent(out Enemy enemy))
		{
			enemy.TakeDamage(1);
		}
		Destroy(gameObject);
	}

}

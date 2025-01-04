using UnityEngine;

public class BaseCamp : MonoBehaviour
{
	public Health health;
	public float maxHp = 100f;

	private void Awake()
	{
		health = GetComponent<Health>();
		health.Init(maxHp);
		health.OnDeath += Die;
	}
	
	public void TakeDamage(float damage)
	{
		health.TakeDamage(damage);
	}
	
	public void Die()
	{
		Debug.Log("BaseCamp Destroyed");
		// Destroy(gameObject);
	}
}

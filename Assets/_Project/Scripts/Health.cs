using System;
using UnityEngine;

[Serializable]
public class Health : MonoBehaviour
{
	public float maxHp = 100f;
	public float hp = 100f;
	public Action OnDeath;
	
	public void Init(float maxHp)
	{
		this.maxHp = maxHp;
		hp = maxHp;
	}

	private void Awake()
	{
		hp = maxHp;
	}

	public void TakeDamage(float damage)
	{
		hp -= damage;
		if (hp <= 0)
		{
			OnDeath?.Invoke();
		}
	}
}

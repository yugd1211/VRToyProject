using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public ParticleSystem deathEffect;
	public GameObject ptsPrefab;
	public Health Health = new Health();
	public float maxHp = 1f;
	public float attackDamage = 5f;
	public float attackRate = 1f;
	public int score = 5;
	
	// public 
	
	private NavMeshAgent _agent;
	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		Health = GetComponent<Health>();
		Health.Init(maxHp);
		Health.OnDeath += Die;
	}

	private void Start()
	{
		_agent.SetDestination(GameManager.Instance.baseCamp.transform.position);
	}
	
	public void TakeDamage(float damage)
	{
		Health.TakeDamage(damage);
	}

	public void Die()
	{
		Destroy(gameObject);
		ParticleSystem ps = Instantiate(deathEffect, transform.position + Vector3.up, Quaternion.identity);
		ps.Play();
		Destroy(ps.gameObject, ps.main.duration);
		GameManager.Instance.score += this.score;
		Instantiate(ptsPrefab, transform.position + Vector3.up, Quaternion.identity);
	}

	public void OnCollisionEnter(Collision other)
	{
		if (other.collider.TryGetComponent(out BaseCamp baseCamp))
		{
			StartCoroutine(AttackCoroutine());
		}
	}

	public void OnCollisionExit(Collision other)
	{
		if (other.collider.TryGetComponent(out BaseCamp baseCamp))
		{
			StopAllCoroutines();
		}
	}

	private IEnumerator AttackCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(attackRate);
			// aniation.attack 실행해야함
			print($"Attack {Vector3.Distance(transform.position, GameManager.Instance.baseCamp.transform.position)}");
			if (Vector3.Distance(transform.position, GameManager.Instance.baseCamp.transform.position) < 1f)
			{
				GameManager.Instance.baseCamp.TakeDamage(attackDamage);
			}
		}
	}
}

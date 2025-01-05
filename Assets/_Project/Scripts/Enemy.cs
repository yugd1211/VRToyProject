using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
	public ParticleSystem deathEffect;
	public GameObject ptsPrefab;
	[SerializeField] private Health health;
	public float maxHp = 1f;
	public float attackDamage = 5f;
	public float attackRate = 1f;
	public int score = 5;
	private Animator _animator;

	[HideInInspector] public EnemySpawner enemySpawner;
	
	// public 
	
	private NavMeshAgent _agent;
	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		_animator = GetComponent<Animator>();
		health = GetComponent<Health>();
		health.Init(maxHp);
		health.OnDeath += Die;
	}

	private void Update()
	{
		if (GameManager.Instance.isGameOver)
		{
			_agent.isStopped = true;
			_animator.SetBool("Win", true);
		}
	}

	private void Start()
	{
		_agent.SetDestination(GameManager.Instance.baseCamp.transform.position);
	}
	
	public void TakeDamage(float damage)
	{
		health.TakeDamage(damage);
	}

	public void Die()
	{
		Destroy(gameObject);
		ParticleSystem ps = Instantiate(deathEffect, transform.position + Vector3.up, Quaternion.identity);
		ps.Play();
		Destroy(ps.gameObject, ps.main.duration);
		GameManager.Instance.score += this.score;
		enemySpawner.enemies.Remove(this);
		Instantiate(ptsPrefab, transform.position + Vector3.up, Quaternion.identity);
	}

	public void OnCollisionEnter(Collision other)
	{
		if (GameManager.Instance.isGameOver) return;
		if (other.collider.TryGetComponent(out BaseCamp baseCamp))
		{
			_animator.SetBool("Attack", true);
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
			if (GameManager.Instance.isGameOver)
			{
				yield break;
			}
			yield return new WaitForSeconds(attackRate);
			if (Vector3.Distance(transform.position, GameManager.Instance.baseCamp.transform.position) < 1f)
			{
				GameManager.Instance.baseCamp.TakeDamage(attackDamage);
			}
		}
	}
}

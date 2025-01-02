using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	private NavMeshAgent _agent;
	public float maxHp = 1f;
	public float hp = 1f;
	
	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		_agent.speed = 2f;
	}

	private void Start()
	{
		_agent.SetDestination(GameManager.Instance.baseCamp.transform.position);
	}

	public void TakeDamage(float damage)
	{
		hp -= damage;
		if (hp <= 0)
		{
			Destroy(gameObject);
		}
	}
}

using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
	public Transform _target;
	private Slider _slider;
	private Enemy _enemy;

	private void Start()
	{
		_enemy = GetComponentInParent<Enemy>();
		_slider = GetComponent<Slider>();
	}

	// 항상 target을 바라보게 하기 위해 LateUpdate 사용
	private void LateUpdate()
	{
		if (_target == null)
		{
			Destroy(gameObject);
			return;
		}
		
		_slider.value = _enemy.hp / _enemy.maxHp;
		
		// 방향을 항상 target을 바라보게 함
		transform.LookAt(_target);
	}
}

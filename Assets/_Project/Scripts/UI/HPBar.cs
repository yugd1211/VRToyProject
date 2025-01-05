using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
	public bool isLookAtCamera = true;
	private Slider _slider;
	private Health _health;

	private void Start()
	{
		_slider = GetComponent<Slider>();
		_health = GetComponentInParent<Health>();
	}

	// 항상 target을 바라보게 하기 위해 LateUpdate 사용
	private void LateUpdate()
	{
		_slider.value = _health.hp / _health.maxHp;
		
		// 방향을 항상 카메라를 바라보게 함
		if (isLookAtCamera)
			transform.LookAt(Camera.main.transform);
	}
}

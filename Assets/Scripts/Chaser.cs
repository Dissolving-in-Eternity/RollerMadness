using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour {
	
    // Скорость погони врага
	public float speed = 20.0f;
	public float minDist = 1f;
    // Переменная для хранения цели, за которой гонятся
	public Transform target;

	// Инициализация
	void Start () 
	{
		// Если цель не назначена, назначаем объект с тегом 'Player'
		if (target == null) {

			if (GameObject.FindWithTag ("Player")!=null)
			{
				target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
			}
		}
	}

    // Update вызывается один раз/кадр
    void Update () 
	{
		if (target == null)
			return;

		// Назначаем цель для врагов
		transform.LookAt(target);

		// Назначаем дистанцию между целью и врагом
		float distance = Vector3.Distance(transform.position,target.position);

        // При условии, что враг дальше, чем минимальное расстояние, двигаться по направлению к игроку
        if (distance > minDist)	
			transform.position += transform.forward * speed * Time.deltaTime;	
	}

	// Назначение цели для погони
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

}

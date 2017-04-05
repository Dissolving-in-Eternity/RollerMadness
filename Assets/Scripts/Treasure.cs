using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour {

	public int value = 10;
	public GameObject explosionPrefab;

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			if (GameManager.gm!=null)
			{
				// Говорим game manager'у собрать
				GameManager.gm.Collect (value);
			}
			
			// взрываем
			if (explosionPrefab != null) {
				Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			}
			
			// разрушаем объект, после того как он собран
			Destroy (gameObject);
		}
	}
}

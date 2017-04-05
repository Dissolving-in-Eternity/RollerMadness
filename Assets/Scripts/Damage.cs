using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	
	public float damageAmount = 10.0f;
	
	public bool damageOnTrigger = true;
	public bool damageOnCollision = false;
	public bool continuousDamage = false;
	public float continuousTimeBetweenHits = 0;

    //переменные, касающиеся взрыва при ударе (область эффекта)
    public bool destroySelfOnImpact = false;	
	public float delayBeforeDestroy = 0.0f;
	public GameObject explosionPrefab;

	private float savedTime = 0;

    //используется для таких вещей (триггеры), как пули
    void OnTriggerEnter(Collider collision)					 
	{
		if (damageOnTrigger) {
            // Если игрок попал в себя собственными пулями - игнорировать урон
            if (this.tag == "PlayerBullet" && collision.gameObject.tag == "Player")	
				return;
		    //Если объект, которому наносится урон, имеет скрипт 'Health', нанести урон
			if (collision.gameObject.GetComponent<Health> () != null) {	
				collision.gameObject.GetComponent<Health> ().ApplyDamage (damageAmount);
		
				if (destroySelfOnImpact) {
                    //Уничтожить объект, когда в него попадает пуля
                    Destroy (gameObject, delayBeforeDestroy);	 
				}
			
				if (explosionPrefab != null) {
					Instantiate (explosionPrefab, transform.position, transform.rotation);
				}
			}
		}
	}

    // используется для вещей, которые взрываются при ударе (не триггеры)
    void OnCollisionEnter(Collision collision) 						
	{	
		if (damageOnCollision) {
            // Если игрок сам нанёс себе урон - игнорировать 
            if (this.tag == "PlayerBullet" && collision.gameObject.tag == "Player")	
				return;

            //Если объект, которому наносится урон, имеет скрипт 'Health', нанести урон
            if (collision.gameObject.GetComponent<Health> () != null) {	
				collision.gameObject.GetComponent<Health> ().ApplyDamage (damageAmount);
			
				if (destroySelfOnImpact) {
                    //Уничтожить объект при столкновении
                    Destroy(gameObject, delayBeforeDestroy);	  
				}
			
				if (explosionPrefab != null) {
					Instantiate (explosionPrefab, transform.position, transform.rotation);
				}
			}
		}
	}

    // используется для повреждений по времени
    void OnCollisionStay(Collision collision) 
	{
		if (continuousDamage) {
            //срабатывает только если что-то попадает в игрока
            if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Health> () != null) {	
				if (Time.time - savedTime >= continuousTimeBetweenHits) {
					savedTime = Time.time;
					collision.gameObject.GetComponent<Health> ().ApplyDamage (damageAmount);
				}
			}
		}
	}
	
}
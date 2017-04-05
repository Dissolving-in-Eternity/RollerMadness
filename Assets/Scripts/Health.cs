using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public enum deathAction {loadLevelWhenDead,doNothingWhenDead};
	
	public float healthPoints = 1f;
	public float respawnHealthPoints = 1f;      //базовое количество очков здоровья

    //жизни и переменные для респауна
    public int numberOfLives = 1;				
	public bool isAlive = true;	

	public GameObject explosionPrefab;
	
	public deathAction onLivesGone = deathAction.doNothingWhenDead;
	
	public string LevelToLoad = "";
	
	private Vector3 respawnPosition;
	private Quaternion respawnRotation;
	

	// инициализация
	void Start () 
	{
		// сохраняет начальную позицию как позицию для респауна
		respawnPosition = transform.position;
		respawnRotation = transform.rotation;
		
		if (LevelToLoad=="")                    // по умолчанию для текущего уровня
		{
			LevelToLoad = Application.loadedLevelName;
		}
	}
	
	void Update () 
	{
		if (healthPoints <= 0) {				// если объект "мёртв"
			numberOfLives--;					// уменьшаем кол-во жизней
			
			if (explosionPrefab!=null) {
				Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			}
			
			if (numberOfLives > 0) {            // респаун
                // сбрасывает игрока в позицию для респауна
                transform.position = respawnPosition;	
				transform.rotation = respawnRotation;
                //предоставляет игроку полную шкалу здоровья
				healthPoints = respawnHealthPoints;	
			} else { // действия после окончания ВСЕХ жизней)
				isAlive = false;
				
				switch(onLivesGone)
				{
				case deathAction.loadLevelWhenDead:
					Application.LoadLevel (LevelToLoad);
					break;
				case deathAction.doNothingWhenDead:
					// Ничего не делаем, смерть будет обработана в другом месте
					break;
				}
				Destroy(gameObject);
			}
		}
	}
	
	public void ApplyDamage(float amount)
	{	
		healthPoints = healthPoints - amount;	
	}
	
	public void ApplyHeal(float amount)
	{
		healthPoints = healthPoints + amount;
	}

	public void ApplyBonusLife(int amount)
	{
		numberOfLives = numberOfLives + amount;
	}
	
	public void updateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation) {
		respawnPosition = newRespawnPosition;
		respawnRotation = newRespawnRotation;
	}
}

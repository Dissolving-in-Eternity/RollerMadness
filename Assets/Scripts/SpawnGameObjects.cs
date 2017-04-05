using UnityEngine;
using System.Collections;

public class SpawnGameObjects : MonoBehaviour {

	public GameObject spawnPrefab;

    //минимальное время между спауном
	public float minSecondsBetweenSpawning = 3.0f;
    //минимальное время между спауном
    public float maxSecondsBetweenSpawning = 6.0f;

	public Transform chaseTarget;
	
	private float savedTime;
	private float secondsBetweenSpawning;

	void Start () {
		savedTime = Time.time;
        // случайное время спауна
		secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
	}
	
	void Update () {
		if (Time.time - savedTime >= secondsBetweenSpawning) // время ли спауниться снова?
		{
			MakeThingToSpawn();
			savedTime = Time.time;                           // хранение для следующего спауна
			secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
		}	
	}

	void MakeThingToSpawn()
	{
		// создание нового GameObject'а
		GameObject clone = Instantiate(spawnPrefab, transform.position, transform.rotation) as GameObject;

		// установить chaseTarget
		if ((chaseTarget != null) && (clone.gameObject.GetComponent<Chaser> () != null))
		{
			clone.gameObject.GetComponent<Chaser>().SetTarget(chaseTarget);
		}
	}
}

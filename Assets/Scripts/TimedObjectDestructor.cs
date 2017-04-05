using UnityEngine;
using System.Collections;

public class TimedObjectDestructor : MonoBehaviour {

	public float timeOut = 1.0f;
	public bool detachChildren = false;

	void Awake () {
		// Приглашение в DestroyNow функцию после timeOut секунд
		Invoke ("DestroyNow", timeOut);
	}
	
	void DestroyNow ()
	{
        // Отделить "детей" прежде чем уничтожить, LOL
		if (detachChildren) { 
			transform.DetachChildren ();
		}
		DestroyObject (gameObject);
	}
}

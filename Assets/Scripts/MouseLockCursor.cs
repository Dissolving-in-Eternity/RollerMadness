using UnityEngine;
using System.Collections;

public class MouseLockCursor : MonoBehaviour {

	public bool isCursorLock = true;

	void Start () {
        //проверяем, заблокирован ли курсор
		LockCursor (isCursorLock);
	}
	
	void Update() {
        //блокировка курсора при игре
		if(Input.GetButtonDown("Cancel")){
			LockCursor (false);
		}
		if(Input.GetButtonDown("Fire1")){
			LockCursor (true);
		}
	}

	private void LockCursor(bool isLocked)
	{
        //делаем курсор невидимым
		if (isLocked) 
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		} else {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}

using UnityEngine;
using System.Collections;


public class UIButtonLevelLoad : MonoBehaviour {
	
	public string LevelToLoad;
	
	public void loadLevel() {
		//Загружаем указанный уровень
		Application.LoadLevel(LevelToLoad);
	}
}

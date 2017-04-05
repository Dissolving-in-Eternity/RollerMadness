using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	
    //скорость вращения
	public float speed = 10.0f;
	
    //определяет в каком направлении вращаться
	public enum whichWayToRotate {AroundX, AroundY, AroundZ}

    //обозначаем, что хотим применить вращение относительно оси 'x'
	public whichWayToRotate way = whichWayToRotate.AroundX;
	
	void Update () {
        //применяем вращение относительно выбранной оси
		switch(way)
		{
		case whichWayToRotate.AroundX:
			transform.Rotate(Vector3.right * Time.deltaTime * speed);
			break;
		case whichWayToRotate.AroundY:
			transform.Rotate(Vector3.up * Time.deltaTime * speed);
			break;
		case whichWayToRotate.AroundZ:
			transform.Rotate(Vector3.forward * Time.deltaTime * speed);
			break;
		}	
	}
}
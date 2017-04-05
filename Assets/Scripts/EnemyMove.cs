using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	public float moveSpeed = 5f;		// скорость передвижения врага
	public GameObject[] myWaypoints;	// все точки маршрута
	private int myWaypointId = 0;		// используется как индекс My_Waypoints
	
	
	void EnemyMovement() {
		// Если ничего нет в My_Waypoints
		if(myWaypoints.Length != 0) {

            // если враг находится достаточно близко к точке маршрута, сделать его новой целью следующую точку
            if (Vector3.Distance(myWaypoints[myWaypointId].transform.position, transform.position) <= 0) {
				myWaypointId++;
			}
			
			if(myWaypointId >= myWaypoints.Length) {
				myWaypointId = 0;
			}
			
			// двигаться в направлении точки маршрута
			transform.position = Vector3.MoveTowards(transform.position, myWaypoints[myWaypointId].transform.position, moveSpeed * Time.deltaTime);
		}
	}
	
	void Update () {
		EnemyMovement();
	}
}
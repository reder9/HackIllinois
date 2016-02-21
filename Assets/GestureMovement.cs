using UnityEngine;
using System.Collections;

public class GestureMovement : MonoBehaviour {

	public GameObject Player;
	public float Force_Multiplier;
	private float Y_Before;
	private float Y_After;


	// Use this for initialization
	void Start () {
		Y_Before = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Y_After = this.gameObject.transform.position.y;

		float dy = getChangeInY();
		Player.GetComponent<Rigidbody> ().velocity = Player.gameObject.transform.forward * dy * Force_Multiplier;

		Y_Before = Y_After;
	}

	// used to calculate the change of position in Y
	float getChangeInY() {
		return Mathf.Abs(Y_Before - Y_After);
	}
}
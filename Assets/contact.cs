using UnityEngine;
using System.Collections;
using Pose = Thalmic.Myo.Pose;

public class contact : MonoBehaviour {

	public GameObject RightHandMyo;
	public GameObject LeftHandMyo;
	private ThalmicMyo RightThalmicMyo;
	private ThalmicMyo LeftThalmicMyo;
	private bool touching;
	private bool Moveable;

	private bool carrying;

	GameObject hand;

	// Use this for initialization
	void Start () {

		touching = false;
		RightThalmicMyo = RightHandMyo.GetComponent<ThalmicMyo> ();
		LeftThalmicMyo = LeftHandMyo.GetComponent<ThalmicMyo> ();

	}
	
	// Update is called once per frame
	void Update () {

		Moveable = (RightThalmicMyo.pose == Pose.Fist || LeftThalmicMyo.pose == Pose.Fist);
		if (Moveable && touching) {
			carrying = true;
			this.transform.parent = hand.transform;
		}

		if (carrying && (RightThalmicMyo.pose == Pose.FingersSpread || LeftThalmicMyo.pose == Pose.FingersSpread)) {
			this.transform.parent = null;
			this.gameObject.AddComponent<Rigidbody> ();
			this.GetComponent<Rigidbody> ().useGravity = true;
			carrying = false;
			touching = false;
		}



	}

	void OnTriggerEnter(Collider other) {

		print ("Here");
		if (other.tag == "Hands") {
			touching = true;

			hand = other.gameObject;

		}


	}

	void OnTriggerExit(Collider other) {

		if (other.tag == "Hands") {
			touching = false;

			this.transform.parent = null;
		}


	}
}

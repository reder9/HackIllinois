using UnityEngine;
using System.Collections;
using Pose = Thalmic.Myo.Pose;

public class TurningManager : MonoBehaviour {

	public GameObject RightMyo;
	public GameObject LeftMyo;
	public float rotation_speed;
	private ThalmicMyo LeftThalmicMyo;
	private ThalmicMyo RightThalmicMyo;

	private bool left = false;
	private bool right = false;

	// Use this for initialization
	void Start () {
		RightThalmicMyo = RightMyo.GetComponent<ThalmicMyo> ();
		LeftThalmicMyo = LeftMyo.GetComponent<ThalmicMyo> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		left = (RightThalmicMyo.pose == Pose.WaveIn &&
			LeftThalmicMyo.pose == Pose.WaveOut);

		right = RightThalmicMyo.pose == Pose.WaveOut &&
			LeftThalmicMyo.pose == Pose.WaveIn; 

		if (left) {
			this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y - rotation_speed,
			                                           this.transform.rotation.z);

		} else if (right) {
			this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y + rotation_speed,
			                                           this.transform.rotation.z);

		}

		else if (RightThalmicMyo.pose == Pose.Fist || LeftThalmicMyo.pose == Pose.Fist){
			left = false;
			right = false;

		}
	}

	bool canTurnLeft() {
		if (RightThalmicMyo.pose == Pose.WaveIn &&
		    LeftThalmicMyo.pose == Pose.WaveOut) {
			return true;
		} else {
			return false;
		}
	}

	bool canTurnRight() {
		if (RightThalmicMyo.pose == Pose.WaveOut &&
		    LeftThalmicMyo.pose == Pose.WaveIn) {
			return true;
		} else {
			return false;
		}
	}
}
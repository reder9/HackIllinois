using UnityEngine;
using System.Collections;

public class KeepStable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(this.transform.position.x, 10, this.transform.position.z);
	}
}

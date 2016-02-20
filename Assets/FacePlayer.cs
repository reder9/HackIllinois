using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);

	}
}

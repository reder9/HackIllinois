using UnityEngine;
using System.Collections;

public class settitle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.name = this.transform.parent.name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

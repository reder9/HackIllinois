using UnityEngine;
using System.Collections;

public class setName : MonoBehaviour {

	// Use this for initialization
	void Start () {

        this.gameObject.name = this.transform.parent.name;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

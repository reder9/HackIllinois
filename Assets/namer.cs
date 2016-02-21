using UnityEngine;
using System.Collections;

public class namer : MonoBehaviour {

    public string name;

	// Use this for initialization
	void Start () {
        this.gameObject.name = name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

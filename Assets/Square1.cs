﻿using UnityEngine;
using System.Collections;

public class Square1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player"){


            other.transform.parent.transform.position = new Vector3(-5, 1, 20);
        }
    }

}
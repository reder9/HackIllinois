using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class getPAr : MonoBehaviour {

	// Use this for initialization
	void Start () {

        this.GetComponent<Text>().text = this.transform.parent.parent.parent.gameObject.name;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

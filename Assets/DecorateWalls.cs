using UnityEngine;
using System.Collections;

public class DecorateWalls : MonoBehaviour {


    public Material[] walls;

    public Material[] floors;

	// Use this for initialization
	void Start () {


        this.gameObject.GetComponent<Renderer>().material = floors[0];

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

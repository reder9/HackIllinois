using UnityEngine;
using System.Collections;
using System.IO;

public class copyDoc : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Player" && other.tag != "Process" && other.tag != "Hands")
        {

            File.Copy(other.name, System.Environment.SpecialFolder.MyDocuments.ToString() + "/a.txt");

        }
    }

}
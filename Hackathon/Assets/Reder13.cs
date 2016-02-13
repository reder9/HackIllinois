using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Reder13 : MonoBehaviour {

	// Use this for initialization
	void Start () {


        Process[] running = Process.GetProcesses();
        
        for (int i =0; i < running.Length; i++)
        {
            print(running[i].ProcessName);
            print(running[i].Id);
           
        }


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

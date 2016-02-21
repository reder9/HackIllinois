using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Reder13 : MonoBehaviour {

    // Use this for initialization

    public GameObject process;
    public GameObject ui;
    public float delay;
    private int i = 0;
    Process[] running;
    private IEnumerator coroutine;

    void Start() {

        running = Process.GetProcesses();
        coroutine = SpawnProcesses(delay);
        StartCoroutine(coroutine);

    }


    IEnumerator SpawnProcesses(float waitTime)
    {

        while (i < running.Length) {
        yield return new WaitForSeconds(waitTime);
        GameObject parent = (GameObject) Instantiate(process, new Vector3(Random.Range(0, 10), 1.0f, Random.Range(10, 15)), Quaternion.identity);
            parent.transform.parent = this.gameObject.transform;
        GameObject child = (GameObject) Instantiate(ui, new Vector3(parent.transform.position.x, 2.5f, parent.transform.position.z), Quaternion.identity);

            parent.gameObject.name = running[i].ProcessName;
            child.gameObject.transform.parent = parent.gameObject.transform;
            child.GetComponent<ProcessDisplay>().name = running[i].ProcessName;
            child.GetComponent<ProcessDisplay>().pid = "PID: " + running[i].Id.ToString();


            i++;
         }
        
            StopCoroutine(coroutine);
        
            //print(running[i].ProcessName);
            //print(running[i].Id);
    }

	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using System.IO;

public class DestroyFile : MonoBehaviour {

    public GameObject exp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag != "Player" && other.tag != "Process" && other.tag !="Hands")
        {

            Instantiate(exp, exp.transform.position, exp.transform.rotation);
            print(other.name + "getting deleted");

            try
            {
                File.Delete(this.name);

            }
           
            catch (IOException e)
            {
               print("The process failed: {0}");
            }
            
            Destroy(other.gameObject);
        }
    }

}

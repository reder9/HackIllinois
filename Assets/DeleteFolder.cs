using UnityEngine;
using System.Collections;
using System.IO;

public class DeleteFolder : MonoBehaviour
{

    public GameObject exp;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Player" && other.tag != "Process" && other.tag != "Hands")
        {

            Instantiate(exp, exp.transform.position, exp.transform.rotation);

            print(other.name + "getting deleted");
            
            if (other.name != "C:'\'Users'\'caleb'\'Desktop'\'HackIllinois"){
            Directory.Delete(other.name);
        }

            Destroy(other.gameObject);
        }

    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class getsize : MonoBehaviour {

	// Use this for initialization
	void Start () {


        long size = new FileInfo(this.name).Length;
        string bytes = "Bytes";

        if (size >= Mathf.Pow(1024, 6))
        {

            size /= (long)(Mathf.Pow(1024, 6));
            bytes = "GB";
        }

        else if (size >= Mathf.Pow(1024, 3))
        {

            size /= (long)Mathf.Pow(1024, 3);
            bytes = "MB";
        }

        else if (size >= Mathf.Pow(1024, 1))
        {

            size /= (long)Mathf.Pow(1024, 1);
            bytes = "KB";
        }


        this.GetComponent<Text>().text = this.transform.parent.parent.parent.gameObject.name;

           

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class setUi : MonoBehaviour {

    public GameObject nametag;
    private GameObject tem;

	// Use this for initialization
	void Start () {
        
        GameObject tem = (GameObject) Instantiate(nametag, this.transform.position, Quaternion.Euler(-270,0,0));
        tem.transform.localPosition = new Vector3(0, 0, 0);
        tem.GetComponent<FileDisplay>().name = this.gameObject.name;

        long size = new FileInfo(this.name).Length;
        string bytes = "Bytes";

         if (size >= Mathf.Pow(1024, 6))
            {

                size /= (long)( Mathf.Pow(1024, 6));
                bytes = "GB";
            }

            else if (size >= Mathf.Pow(1024, 3))
            {

                size /= (long) Mathf.Pow(1024, 3);
                bytes = "MB";
            }

            else if (size >= Mathf.Pow(1024, 1))
            {

                size /= (long) Mathf.Pow(1024, 1);
                bytes = "KB";
            }
            this.nametag.GetComponent<FileDisplay>().size = System.Math.Round( (float) size, 2).ToString() + " " + bytes;
           
        

	}
	
	// Update is called once per frame
	void Update () {
        tem.GetComponent<FileDisplay>().nameText.text = this.gameObject.name;
      
	}
}

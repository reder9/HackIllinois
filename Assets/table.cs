using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class table : MonoBehaviour {

    public GameObject PDF;
    public GameObject Docx;
    public GameObject TXT;
    public GameObject CD;
    public GameObject Unknown;


    public Vector3[] locations;

    public string[] files;

    

	// Use this for initialization
	void Start () {

        GameObject a;

        for (int i = 0; i < files.Length; i++)
        {
            string cur = files[i].ToLower();
            if ( cur.Contains(".txt")){

                a = (GameObject) GameObject.Instantiate(TXT, locations[i] , TXT.transform.rotation);
                a.transform.parent = this.transform;
                a.name = files[i];
                a.transform.localPosition = locations[i];

            }

            else if (cur.Contains(".pdf"))
            {
                   a = (GameObject)  GameObject.Instantiate(PDF, locations[i], PDF.transform.rotation);
                  a.transform.parent = this.transform;
                  a.name = files[i];
                 a.transform.localPosition = locations[i];
            }

            else if (cur.Contains(".docx"))
            {
                   a = (GameObject)  GameObject.Instantiate(Docx, locations[i], Docx.transform.rotation);
                  a.transform.parent = this.transform;
                  a.name = files[i];
                 a.transform.localPosition = locations[i];
            }

            else if (cur.Contains(".mp3"))
            {
                 a = (GameObject)  GameObject.Instantiate(CD, locations[i], CD.transform.rotation);
                  a.transform.parent = this.transform;
                  a.name = files[i];
                 a.transform.localPosition = locations[i];
            }

            else if (cur!="")
            {

                  a = (GameObject)  GameObject.Instantiate(Unknown, locations[i], Unknown.transform.rotation);
                  a.transform.parent = this.transform;
                  a.name = files[i];
                 a.transform.localPosition = locations[i];
            }

        }



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

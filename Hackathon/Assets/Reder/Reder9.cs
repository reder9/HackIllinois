using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class Reder9 : MonoBehaviour {

    public GameObject AI;
    public GameObject AI2;

	// Use this for initialization
	void Start () {

        //File.Copy("Assets/readme.txt", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) +"/unity.txt");
        //print("File Copied");

        DirectoryInfo info = new DirectoryInfo(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments));
        FileInfo[] files =  info.GetFiles();

        for (int i = 0; i < files.Length; i++)
        {

            GameObject temp = (GameObject) Instantiate(AI, new Vector3(-300 + i*30, AI2.transform.position.y, 0), Quaternion.identity);
            temp.transform.parent = this.gameObject.transform;
            temp.gameObject.GetComponentInChildren<Text>().text = files[i].Name;
            print(files[i].Name);
        }


        print("folders");
        DirectoryInfo[] folders= info.GetDirectories();


        for (int i = 0; i < folders.Length; i++)
        {
            GameObject temp = (GameObject) Instantiate(AI2, new Vector3(-300 + i*30, AI2.transform.position.y, 50), Quaternion.identity);
            temp.transform.parent = this.gameObject.transform;
            print(folders[i].Name);
            temp.gameObject.GetComponentInChildren<Text>().text = folders[i].Name;
            
        }

    }

	
	// Update is called once per frame
	void Update () {
	
	}
}

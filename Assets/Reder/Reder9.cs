using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class Reder9 : MonoBehaviour {


    public GameObject canvas;

    public float height;

    public GameObject file;
    public GameObject directory;

    public float spacing;

	// Use this for initialization
	void Start () {

        GenerateFiles(System.Environment.SpecialFolder.Desktop);
      
    }


    void GenerateFiles(System.Environment.SpecialFolder location) {


        DirectoryInfo info = new DirectoryInfo(System.Environment.GetFolderPath(location));
        FileInfo[] files = info.GetFiles();

        for (int i = 0; i < files.Length; i++)
        {

            GameObject temp = (GameObject)Instantiate(file, new Vector3(i *spacing, height,0) , Quaternion.Euler(0, 0, 0));
            temp.name = files[i].FullName;
            temp.transform.parent = canvas.gameObject.transform;
            temp.gameObject.GetComponent<FileDisplay>().name = files[i].Name;

            string bytes = "Bytes";
            float size = (float)files[i].Length;

            if (size >= Mathf.Pow(10, 9))
            {

                size /= Mathf.Pow(10, 9);
                bytes = "GB";
            }

            else if (size >= Mathf.Pow(10, 6))
            {

                size /= Mathf.Pow(10, 6);
                bytes = "MB";
            }

            else if (size >= Mathf.Pow(10, 3))
            {

                size /= Mathf.Pow(10, 3);
                bytes = "KB";
            }
            temp.gameObject.GetComponent<FileDisplay>().size = System.Math.Round(size, 2).ToString() + " " + bytes;
           
        }


        DirectoryInfo[] folders = info.GetDirectories();

        int num = folders.Length;
 
        this.transform.localScale = new Vector3(num * spacing, .01f, this.transform.localScale.z);
        this.transform.position = new Vector3(this.transform.position.x, .01f, this.transform.localScale.z * 5f);


        for (int i = 0; i < folders.Length; i++)
        {

            GameObject temp = (GameObject)Instantiate(directory,  new Vector3(this.transform.localScale.x * -1 + this.transform.localScale.x *3, height, this.transform.localScale.z  + i + spacing), Quaternion.Euler(0, 0, 0));
            temp.name = folders[i].FullName;
            temp.transform.parent = canvas.gameObject.transform;
            temp.gameObject.GetComponent<DirectoryDisplay>().name = folders[i].Name;

        }

    }
    
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class Reder9 : MonoBehaviour {


    public GameObject grass;
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
            temp.transform.parent = this.gameObject.transform;
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
        if (folders.Length < 2)
        {
            num = 2;
        }


        for (int i = 0; i < num; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject a = (GameObject) Instantiate(grass, new Vector3(i*5f, .01f, j*5f), Quaternion.Euler(90,0,0));
                a.transform.parent = this.gameObject.transform;
                if (j == 9){
                      GameObject temp = (GameObject)Instantiate(directory, new Vector3(this.transform.localScale.x * -1 + this.transform.localScale.x * 3, height, 5f), Quaternion.Euler(0, 0, 0));
                     temp.name = folders[i].FullName;
                     temp.transform.parent = a.gameObject.transform;
                     temp.transform.position = a.transform.position + new Vector3(0, height, 0);
                temp.gameObject.GetComponent<DirectoryDisplay>().name = folders[i].Name;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

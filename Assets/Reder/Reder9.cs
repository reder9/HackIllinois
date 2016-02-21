using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class Reder9 : MonoBehaviour {


    public GameObject grass;
    public float height;
    public GameObject table;

    public GameObject file;
    public GameObject directory;

    public float spacing;

    string[] abc = new string[5];


	// Use this for initialization
	void Start () {

        GenerateFiles(System.Environment.SpecialFolder.Desktop);
      
    }


    void GenerateFiles(System.Environment.SpecialFolder location) {

        int sum = 0;
        int var = 0;
        int ls = 0;
       
        DirectoryInfo info = new DirectoryInfo(System.Environment.GetFolderPath(location));

        FileInfo[] files = info.GetFiles();

        for (int i = 0; i < files.Length; i++)
        {
            ls = i;

            if (i > 25)
            {
                ls = i-25;
                var++;
            }

           
            if ((i % 5 == 0 && i != 0 )|| i == files.Length-1 )
            {

               
               GameObject c = (GameObject) Instantiate(table, new Vector3(i, 1, i), Quaternion.identity);
               c.transform.localPosition = new Vector3(this.transform.localScale.x +2*(ls+sum), 0, 5 + 1* var);
                c.transform.parent = this.transform;
               
                table.GetComponent<table>().files[0] = abc[0];
                table.GetComponent<table>().files[1] = abc[1];
                table.GetComponent<table>().files[2] = abc[2];
                table.GetComponent<table>().files[3] = abc[3];
                table.GetComponent<table>().files[4] = abc[4];
                abc = new string[5];
                sum++;
            }

                
                abc[(i%5)] = files[i].FullName;
               ;

           
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
                GameObject b= (GameObject) Instantiate(grass, new Vector3(i*5f, .01f, j*5f), Quaternion.Euler(90,0,0));
                b.transform.parent = this.gameObject.transform;
                if (j == 9){
                      GameObject temp = (GameObject)Instantiate(directory, new Vector3(this.transform.localScale.x * -1 + this.transform.localScale.x * 3, height, 5f), Quaternion.Euler(0, 0, 0));
                     temp.name = folders[i].FullName;
                     temp.transform.parent = b.gameObject.transform;
                     temp.transform.position = b.transform.position + new Vector3(0, height, 0);
                temp.gameObject.GetComponent<DirectoryDisplay>().name = folders[i].Name;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

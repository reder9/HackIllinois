using UnityEngine;
using System.Collections;
using System.IO;

public class Warp : MonoBehaviour {

    public GameObject table;

    public GameObject back;

    public GameObject room;

    public GameObject canvas;

    public float destination;
    public float height;

    public float source;


    public GameObject file;
    public GameObject directory;

    private int i=0;
    private int j=0;

    
    private FileInfo[] files;
    private DirectoryInfo[] directories;
    

	// Use this for initialization
	void Start () {
	
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        back = GameObject.FindGameObjectWithTag("Finish");
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {


            if (room != null)
            {

                Destroy(GameObject.FindGameObjectWithTag("BonusRoom"));
            }

                room = (GameObject)Instantiate(room, new Vector3(destination, 0, 0), Quaternion.identity);
                room.transform.parent = canvas.transform;
                rescaleRoom();

           
                GenerateFiles();

                GameObject temp = (GameObject)Instantiate(back, new Vector3(destination, height, -5), Quaternion.identity);
                
                temp.transform.parent = room.transform;
                other.transform.parent.transform.position = new Vector3(destination, height, 0);

            
           
        }
    }


    void rescaleRoom()
    {

        DirectoryInfo info = new DirectoryInfo(this.gameObject.name);
        DirectoryInfo[] dir = info.GetDirectories();

        if (dir.Length > 2)
        {
            this.room.transform.localScale = new Vector3(dir.Length, 2, dir.Length);
        }

        else
        {
            this.room.transform.localScale = new Vector3(5, 2, 5);
        }
    }



    void GenerateFiles()
    {

        string[] abc = new string[5];
        DirectoryInfo info = new DirectoryInfo(this.gameObject.name);
        files = info.GetFiles();
        int ls;
        int var = 0;
        int sum = 0;
        for (int i = 0; i < files.Length; i++)
        {

            print(files[i].Name);
            ls = i;

            if (i > 25)
            {
                ls = i - 25;
                var++;
            }


            if ((i % 5 == 0 && i != 0) || i == files.Length - 1)
            {

                print("Makin Files...");

                GameObject c = (GameObject)Instantiate(table, new Vector3(i, 1, i), Quaternion.identity);
                c.transform.localPosition = new Vector3(destination +(1+sum), 0, 5 + 1 * var);
                c.transform.parent = this.transform;

                table.GetComponent<table>().files[0] = abc[0];
                table.GetComponent<table>().files[1] = abc[1];
                table.GetComponent<table>().files[2] = abc[2];
                table.GetComponent<table>().files[3] = abc[3];
                table.GetComponent<table>().files[4] = abc[4];
                abc = new string[5];
                sum++;
            }


            abc[(i % 5)] = files[i].FullName;
            ;


        }

        DirectoryInfo[] folders = info.GetDirectories();
      
        int k = 0;

        
            k = 0;
            for (int i = 0; i < folders.Length; i++)
            {

                int xOff = i;

                if (i > room.transform.localScale.x - 1)
                {
                    xOff = 0;
                    k++;
                }


                GameObject temp = (GameObject)Instantiate(directory, new Vector3(destination - this.transform.localScale.x / 2 + i * height, k), Quaternion.Euler(0, 0, 0));
                temp.name = folders[i].FullName;
                temp.transform.parent = room.gameObject.transform;
                temp.transform.localPosition = new Vector3((room.transform.localScale.x ) / -2 + xOff + .5f, height, (room.transform.localScale.z  / 2f) - 1.75f - k);
                temp.gameObject.GetComponent<DirectoryDisplay>().name = folders[i].Name;

            

        }
    }

}

using UnityEngine;
using System.Collections;
using System.IO;

public class Warp : MonoBehaviour
{


    public GameObject room;

    public GameObject canvas;
    public GameObject tile;
    public float destination;
    public float height;

    public GameObject file;
    public GameObject directory;

    private int i = 0;
    private int j = 0;

    private FileInfo[] files;
    private DirectoryInfo[] directories;

    // Use this for initialization
    void Start()
    {

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        room = GameObject.FindGameObjectWithTag("BonusRoom");

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {


        if (this.name != "Home")
        {
            GenerateFiles();
        }

        if (room != null)
        {
            rescaleRoom();
        }

        other.gameObject.transform.position = new Vector3(destination, height, 0);

    }


    void rescaleRoom()
    {

        this.room.transform.localScale = new Vector3(10, 2, 10);

    }



    void GenerateFiles()
    {


        DirectoryInfo info = new DirectoryInfo(this.gameObject.name);
        files = info.GetFiles();

        for (int i = 0; i < files.Length; i++)
        {
            GameObject temp = (GameObject)Instantiate(file, new Vector3(destination - this.room.transform.localScale.x / 2 + i * height, 0), Quaternion.Euler(0, 0, 0));
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
   

        for (int i = 0; i < folders.Length; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject a = (GameObject)Instantiate(tile, new Vector3(i * 5f, .01f, j * 5f), Quaternion.Euler(90, 0, 0));
                a.transform.parent = this.gameObject.transform;
                if (j == 9)
                {
                    GameObject temp = (GameObject)Instantiate(directory, new Vector3(this.transform.localScale.x * -1 + this.transform.localScale.x * 3, height, 5f), Quaternion.Euler(0, 0, 0));
                    temp.name = folders[i].FullName;
                    temp.transform.parent = a.gameObject.transform;
                    temp.transform.position = a.transform.position + new Vector3(0, height, 0);
                    temp.gameObject.GetComponent<DirectoryDisplay>().name = folders[i].Name;
                }
            }
        }
    }
}

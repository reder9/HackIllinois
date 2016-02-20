using UnityEngine;
using System.Collections;
using System.IO;

public class Warp : MonoBehaviour {


    public GameObject room;

    public GameObject canvas;

    public float destination;
    public float height;

    public GameObject file;
    public GameObject directory;

    private int i=0;
    private int j=0;

    private FileInfo[] files;
    private DirectoryInfo[] directories;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (this.name != "Home")
            {
                GenerateFiles();
            }

            if (room != null)
            {
                rescaleRoom();
            }
        }
            other.gameObject.transform.position = new Vector3(destination, height, 0);
  
    }



IEnumerator SpawnFiles (float waitTime){

     while (i < files.Length) {

        yield return new WaitForSeconds(waitTime);

            GameObject temp = (GameObject)Instantiate(file, new Vector3(2000 + 10*i, height, 20), Quaternion.Euler(0, 0, 0));
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

     i++;


}




    void rescaleRoom()
    {

        this.room.transform.localScale = new Vector3(10, 2, 10);

    }



    void GenerateFiles()
    {


        DirectoryInfo info = new DirectoryInfo(this.gameObject.name);
        files = info.GetFiles();

        StartCoroutine(SpawnFiles(.1f));

        DirectoryInfo[] folders = info.GetDirectories();

        for (int i = 0; i < folders.Length; i++)
        {

            GameObject temp = (GameObject)Instantiate(directory, new Vector3(2000 + i * 10, height, 40), Quaternion.Euler(0, 0, 0));
            temp.name = folders[i].FullName;
            temp.transform.parent = canvas.gameObject.transform;
            temp.gameObject.GetComponent<DirectoryDisplay>().name = folders[i].Name;

        }


    }

}

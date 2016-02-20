using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DirectoryDisplay : MonoBehaviour {

    public Text nameText;
    public Text sizeText;

    public string name;
    public string size;

    // Use this for initialization
    void Start()
    {

        nameText.text = name;
        sizeText.text = size;

        //calculateSize();
    }

    // Update is called once per frame
    void Update()
    {
       Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        this.transform.LookAt(player.transform);
        this.nameText.transform.LookAt(player.transform.position);
        this.nameText.transform.Rotate(new Vector3(0, 1, 0), 180f);
        this.sizeText.transform.rotation = this.nameText.transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            print("Calculating...");
                //calculateSize();
        }

    }

    void calculateSize()
    {


        DirectoryInfo info = new DirectoryInfo(this.gameObject.name);
        DirectoryInfo[] folders = info.GetDirectories();

        string bytes = "Bytes";

        float size = 0;

        for (int i = 0; i < folders.Length; i++)
        {
            size += GetFolderSize(folders[i]);
        }

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

        this.sizeText.text = System.Math.Round(size, 2).ToString() + " " + bytes;

    }


    long GetFileSize(DirectoryInfo dir)
    {

        FileInfo[] subFiles = dir.GetFiles();
        long size = 0;

        for (int j = 0; j < subFiles.Length; j++)
        {
            size += subFiles[j].Length;
        }
        return size;
    }


    long GetFolderSize(DirectoryInfo dir)
    {

        DirectoryInfo[] subDir = dir.GetDirectories();
        long size = 0;
        for (int i = 0; i < subDir.Length; i++)
        {

            size += GetFileSize(subDir[i]);
            size += GetFolderSize(subDir[i]);

        }

        return size;
    }
}
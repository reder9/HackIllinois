using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class SetDesktop : MonoBehaviour
{


    public float height;

    public GameObject file;
    public GameObject directory;

    public float spacing;

    // Use this for initialization
    void Start()
    {
        GenerateFiles(System.Environment.SpecialFolder.Desktop);
    }

    void Update()
    {


    }

    void GenerateFiles(System.Environment.SpecialFolder location)
    {


        DirectoryInfo info = new DirectoryInfo(System.Environment.GetFolderPath(location));
        FileInfo[] files = info.GetFiles();

        for (int i = 0; i < files.Length; i++)
        {

            GameObject temp = (GameObject)Instantiate(file, new Vector3(i * spacing, height, 0), Quaternion.Euler(0, 0, 0));
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

        for (int i = 0; i < folders.Length; i++)
        {

            GameObject temp = (GameObject)Instantiate(directory, new Vector3(i * spacing, height, 20), Quaternion.Euler(0, 0, 0));
            temp.name = folders[i].FullName;
            temp.transform.parent = this.gameObject.transform;
            temp.gameObject.GetComponent<DirectoryDisplay>().name = folders[i].Name;

        }

    }
}
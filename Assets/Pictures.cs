using UnityEngine;
using System.Collections;
using System.IO;


public class Pictures : MonoBehaviour {

    public GameObject[] pics;
    public string[] titles;

    WWW pic;
    
    void Start()
    {
        
        DirectoryInfo d = new DirectoryInfo(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures)) ;
        FileInfo[] p = d.GetFiles();

        for (int k = 1; k < 4; k++)
        {

            titles[k-1] =  p[k].FullName;
            print(p[k].FullName);
        }

           // for (int i = 0; i < pics.Length; i++)
            //{
                StartCoroutine(FinishDownload(titles[0]));
                pics[0].GetComponent<Renderer>().material.mainTexture = pic.texture;
            //}

    }

    IEnumerator FinishDownload(string url)
    {
        pic = new WWW(url);

        yield return pic;

    }
}

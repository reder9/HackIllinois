using UnityEngine;
using System.Collections;

public class LoadImage : MonoBehaviour {

    string url = "file://C:/Users/caleb/Desktop/HackIllinois/Assets/Kris/OhNo404.JPG";
    WWW pic;
    // Start a download of the given URL
    // Use this for initialization
    void Start () {

        StartCoroutine(FinishDownload(url));
        this.gameObject.GetComponent<Renderer>().material.mainTexture = pic.texture;

    }

    IEnumerator FinishDownload(string url)
    {
        pic = new WWW(url);

        yield return pic;
    }
    
    
}

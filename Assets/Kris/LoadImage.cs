using UnityEngine;
using System.Collections;

public class LoadImage : MonoBehaviour {

    
    WWW pic;
    // Start a download of the given URL
    // Use this for initialization
    void Start () {

        StartCoroutine(FinishDownload(this.name));
        //this.gameObject.GetComponent<Renderer>().material.mainTexture = pic.texture;

    }

    IEnumerator FinishDownload(string url)
    {
        pic = new WWW(url);

        yield return pic;
    }
    
    
}

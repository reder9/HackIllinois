using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class FileDisplay : MonoBehaviour {

    public Text nameText;
    public Text sizeText;

    public string name;
    public string size;

    // Use this for initialization
    void Start()
    {

        nameText.text = name;
        sizeText.text = size;

    }

    // Update is called once per frame
    void Update()
    {

       
    }


}
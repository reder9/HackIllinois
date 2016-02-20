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

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        this.transform.LookAt(player.transform);
        this.nameText.transform.LookAt(player.transform.position);
        this.nameText.transform.Rotate(new Vector3(0, 1, 0), 180f);
        this.sizeText.transform.rotation = this.nameText.transform.rotation;
        
    }


}
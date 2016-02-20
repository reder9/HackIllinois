using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProcessDisplay : MonoBehaviour {

    public Text nameText;
    public Text pidText;

    public string name;
    public string pid;

    // Use this for initialization
    void Start()
    {

        nameText.text = name;
        pidText.text = pid;

    }

    // Update is called once per frame
    void Update()
    {

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        this.transform.LookAt(player.transform);
        this.nameText.transform.LookAt(player.transform.position);
        this.nameText.transform.Rotate(new Vector3(0, 1, 0), 180f);
        this.pidText.transform.rotation = this.nameText.transform.rotation;
    }


}
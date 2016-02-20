using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour
{

    public float forwardSpeed;
    public float backwardSpeed;
    public float rotationSpeed;
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {

        rb = this.gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");              // 入力デバイスの水平軸をhで定義
        float v = Input.GetAxis("Vertical");                // 入力デバイスの垂直軸をvで定義

        Vector3 velocity = new Vector3(0, 0, v);        // 上下のキー入力からZ軸方向の移動量を取得
                                                        // キャラクターのローカル空間での方向に変換
        velocity = transform.TransformDirection(velocity);

        if (v > 0.1)
        {
            velocity *= forwardSpeed;       // 移動速度を掛ける
        }
        else if (v < -0.1)
        {
            velocity *= backwardSpeed;  // 移動速度を掛ける
        }

        transform.localPosition += velocity * Time.fixedDeltaTime;

        transform.Rotate(0, h * rotationSpeed, 0);

    }
}
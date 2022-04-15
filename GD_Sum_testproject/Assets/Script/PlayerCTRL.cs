using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCTRL : MonoBehaviour
{
    public float speed;
    public float timeLimit;

    private float counter = 0;

    Rigidbody2D body;

    // 読み込み時に動くトコ
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        counter = timeLimit;
    }

    // 60/1秒単位で呼び出されるトコ
    void Update()
    {
        body.velocity = new Vector2(
            Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        TestShot();

        if (counter < 0)
        {
            Debug.Log("カウント");
            counter = timeLimit;
        }
        else
        {
            counter = counter - Time.deltaTime;
        }
    }

    // 射撃（仮）
    void TestShot()
    {
        if (Input.GetMouseButtonDown(0)) { Debug.Log("左クリック");}
    }

}

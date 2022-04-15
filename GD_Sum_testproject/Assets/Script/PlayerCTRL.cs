using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCTRL : MonoBehaviour
{
    public float speed;
    public float timeLimit;

    private float counter = 0;

    Rigidbody2D body;

    // �ǂݍ��ݎ��ɓ����g�R
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        counter = timeLimit;
    }

    // 60/1�b�P�ʂŌĂяo�����g�R
    void Update()
    {
        body.velocity = new Vector2(
            Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        TestShot();

        if (counter < 0)
        {
            Debug.Log("�J�E���g");
            counter = timeLimit;
        }
        else
        {
            counter = counter - Time.deltaTime;
        }
    }

    // �ˌ��i���j
    void TestShot()
    {
        if (Input.GetMouseButtonDown(0)) { Debug.Log("���N���b�N");}
    }

}

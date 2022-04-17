using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCTRL : MonoBehaviour
{
    public float moveSpeed;
    public float timeLimit;
    public int defoAttackTiming;
    public GameObject attackObject;

    private float counter = 0;
    private int attackTiming;

    Rigidbody2D body;

    // �ǂݍ��ݎ��ɓ����g�R
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        counter = timeLimit;
        attackTiming = defoAttackTiming;
    }

    // 60/1�b�P�ʂŌĂяo�����g�R
    void Update()
    {
        body.velocity = new Vector2(
            Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);

        TestShot();

        if (counter < 0)
        {
            attackTiming--;
            counter = timeLimit;
            Debug.Log("�J�E���g");
        }
        else
        {
            counter = counter - Time.deltaTime;
        }

        if (attackTiming == 0)
        {
            Attack();
            attackTiming = defoAttackTiming;
        }
    }

    // �ˌ��i���j
    void TestShot()
    {
        if (Input.GetMouseButtonDown(0)) { Debug.Log("���N���b�N");}
    }

    void Attack()
    {
        Debug.Log("�U��");
        
        //attackObject
        GameObject attack = 
        (GameObject)Instantiate(
            attackObject,
            new Vector3(transform.position.x,transform.position.y,0),
            Quaternion.identity);
    }

}

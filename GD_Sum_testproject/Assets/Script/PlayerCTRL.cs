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

    // 読み込み時に動くトコ
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        counter = timeLimit;
        attackTiming = defoAttackTiming;
    }

    // 60/1秒単位で呼び出されるトコ
    void Update()
    {
        body.velocity = new Vector2(
            Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);

        TestShot();

        if (counter < 0)
        {
            attackTiming--;
            counter = timeLimit;
            Debug.Log("カウント");
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

    // 射撃（仮）
    void TestShot()
    {
        if (Input.GetMouseButtonDown(0)) { Debug.Log("左クリック");}
    }

    void Attack()
    {
        Debug.Log("攻撃");
        
        //attackObject
        GameObject attack = 
        (GameObject)Instantiate(
            attackObject,
            new Vector3(transform.position.x,transform.position.y,0),
            Quaternion.identity);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCTRL : MonoBehaviour
{
    public float moveSpeed;
    public int defoAttackTiming;
    public GameCTRL gamectrl;
    public Text aTcount;
    public float attackUItimer;
    public Text attackUI;

    private int attackTiming = 0;
    private bool isAttack = false;
    private float attackUiTimeleft = 0;

    Rigidbody2D body;

    // �ǂݍ��ݎ��ɓ����g�R
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        attackTiming = defoAttackTiming;
        attackUiTimeleft = attackUItimer;
    }

    // ���t���[���Ăяo�����g�R
    void Update()
    {
        body.velocity = new Vector2(
            Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
        
        if (gamectrl.Metronome() && attackTiming > 0)
        {
            attackTiming--;
        }

        if (attackTiming == 0 && gamectrl.Metronome())
        {
            if (Input.GetKey("space"))
            {
                attackUI.text = "PAUSE...";
                return;
            }
            isAttack = true;
            attackTiming = defoAttackTiming;
        }
        else
        {
            isAttack = false;
        }

        aTcount.text = "ATcount:" + attackTiming;


        if (isAttack)
        {
            attackUI.text = "ATTACK";
            attackUiTimeleft = attackUItimer;
        }

        if (attackUiTimeleft > 0.0f)
        {
            attackUiTimeleft -= Time.deltaTime;
        }
        else if (attackTiming != 0)
        {
            attackUI.text = " ";
        }

    }

    public bool Attack()
    {
        /*
        Debug.Log("�U��");

        //attackObject
        GameObject attack = 
        (GameObject)Instantiate(
            attackObject,
            new Vector3(transform.position.x,transform.position.y,0),
            Quaternion.identity);
        */

        return isAttack;
    }

}

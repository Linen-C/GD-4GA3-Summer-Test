using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCTRL : MonoBehaviour
{
    public float moveSpeed;    // �ړ����x
    public int defoAttackTiming;    // �U���ɕK�v�ȃJ�E���g��
    public GameCTRL gamectrl;    // �Q�[���R���g���[���[
    public Text atCount;    // �J�E���g���̕\��
    public float attackUItimer;    // UI�\������
    public Text attackUI;    // �U���E�ҋ@��Ԃ�UI�\��
    public float defCashTime;   // ��s���͗p

    private int attackTiming = 0;
    private bool isAttack = false;
    private float attackUiTimeleft = 0;
    private float cashTime = 0;

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

        if (Input.GetMouseButtonDown(0))
        {
            cashTime = defCashTime;
        }

        if (cashTime > 0.0f)
        {
            cashTime -= Time.deltaTime;
        }

        if (attackTiming == 0 && cashTime > 0.0f)
        {
            if (gamectrl.Metronome())
            {
                isAttack = true;
                attackTiming = defoAttackTiming;
            }
            /*
            if (Input.GetKey("space"))
            {
                attackUI.text = "PAUSE...";
                return;
            }
            */
        }
        else
        {
            isAttack = false;
        }


        atCount.text = "atCount:" + attackTiming;


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

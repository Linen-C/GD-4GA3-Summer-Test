using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCTRL : MonoBehaviour
{
    public float moveSpeed;    // 移動速度
    public int defoAttackTiming;    // 攻撃に必要なカウント数
    public GameCTRL gamectrl;    // ゲームコントローラー
    public Text atCount;    // カウント数の表示
    public float attackUItimer;    // UI表示時間
    public Text attackUI;    // 攻撃・待機状態のUI表示
    public float defCashTime;   // 先行入力用

    private int attackTiming = 0;
    private bool isAttack = false;
    private float attackUiTimeleft = 0;
    private float cashTime = 0;

    Rigidbody2D body;

    // 読み込み時に動くトコ
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        attackTiming = defoAttackTiming;
        attackUiTimeleft = attackUItimer;
    }

    // 毎フレーム呼び出されるトコ
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
        Debug.Log("攻撃");

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

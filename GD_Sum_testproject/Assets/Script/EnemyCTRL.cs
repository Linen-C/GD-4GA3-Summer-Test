using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCTRL : MonoBehaviour
{
    public GameCTRL gamectrl;    // ゲームコントローラー
    public int defoAttackTiming;    // 攻撃に必要なカウント数
    public Text caveat;

    private int attackTiming = 0;
    private bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        attackTiming = defoAttackTiming;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamectrl.Metronome() && attackTiming > 0)
        {
            attackTiming--;
        }

        if (attackTiming == 0 && gamectrl.Metronome())
        {
            isAttack = true;
            attackTiming = defoAttackTiming;
        }
        else
        {
            isAttack = false;
        }

        /*
        if (attackTiming == 1)
        {
            caveat.text = "!";
        }
        else
        {
            caveat.text = "";
        }
        */

        caveat.text = " " + attackTiming;
    }

    public bool Attack()
    {
        return isAttack;
    }
}

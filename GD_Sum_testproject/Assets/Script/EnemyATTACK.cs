using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATTACK : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // エネミーを除外して判定
        if (other.gameObject.tag == "Enemy") { return; }

        // 命中判定
        //Debug.Log("敵攻撃：「" + other.gameObject.name + "」に命中");
        Debug.Log("被弾！");
    }
}

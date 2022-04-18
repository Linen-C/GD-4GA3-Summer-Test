using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackSELF : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 1.0f);
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーを除外して判定
        if (other.gameObject.tag == "Player") { return; }

        // 命中判定
        Debug.Log("攻撃：「" + other.gameObject.name + "」に命中！");
    }
}

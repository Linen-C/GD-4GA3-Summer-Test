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
        // �G�l�~�[�����O���Ĕ���
        if (other.gameObject.tag == "Enemy") { return; }

        // ��������
        //Debug.Log("�G�U���F�u" + other.gameObject.name + "�v�ɖ���");
        Debug.Log("��e�I");
    }
}

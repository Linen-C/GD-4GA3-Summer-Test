using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATTACK : MonoBehaviour
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
        // �v���C���[�����O���Ĕ���
        if (other.gameObject.tag == "Player") { return; }

        // ��������
        Debug.Log("�U���F�u" + other.gameObject.name + "�v�ɖ����I");
    }
}

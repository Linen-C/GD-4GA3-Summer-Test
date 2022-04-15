using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRAY : MonoBehaviour
{
    private float rotZ = 0;

    // Start
    void Start()
    {
    }

    // Update
    void Update()
    {
        //TestRot();

        // �����̈ʒu
        Vector2 transPos = transform.position;
        //Debug.Log("tX" + transPos.x + "_" + "tY" + transPos.y);

        // �X�N���[�����W�n�̃}�E�X���W�����[���h���W�n�ɏC��
        Vector2 mouseRawPos = Input.mousePosition;
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseRawPos);
        //Debug.Log("mX" + mouseWorldPos.x + "_"+ "mY" + mouseWorldPos.y);

        // �x�N�g�����v�Z
        Vector2 diff = (mouseWorldPos - transPos).normalized;
        
        // ��]�ɑ��
        transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
    }

    void TestRot()
    {


        if (Input.GetKey(KeyCode.J))
        {
            rotZ += 0.5f;
        }
        if (Input.GetKey(KeyCode.L))
        {
            rotZ -= 0.5f;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}

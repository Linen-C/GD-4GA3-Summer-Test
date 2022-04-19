using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRAY : MonoBehaviour
{
    public EnemyCTRL enemyCtrl;
    public GameObject playerObject;
    public GameObject attackObject;
    public GameObject cursor;

    //private float rotZ = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 自分の位置
        Vector2 transPos = transform.position;
        //Debug.Log("tX" + transPos.x + "_" + "tY" + transPos.y);

        Vector2 plPos = playerObject.transform.position;
        //Debug.Log("mX" + mouseWorldPos.x + "_"+ "mY" + mouseWorldPos.y);

        // ベクトルを計算
        Vector2 diff = (plPos - transPos).normalized;

        // 回転に代入
        transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);

        if (enemyCtrl.Attack())
        {
            Trail();
        }
    }

    void Trail()
    {
        //attackObject
        GameObject attack =
        (GameObject)Instantiate(
            attackObject,
            new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0),
            transform.rotation);
    }
}

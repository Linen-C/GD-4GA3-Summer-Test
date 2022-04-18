using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCTRL : MonoBehaviour
{
    public float timeLimit;
    public float defUiTimer;
    public Text counterText;

    private float counter = 0;
    private bool isTick = false;
    private float uiTimer = 0;


    public bool Metronome()
    {
        return isTick;
    }

    void Start()
    {
        counter = timeLimit;
        uiTimer = defUiTimer;
    }

    void Update()
    {
        if (counter < 0.0f)
        {
            isTick = true;
            counter = timeLimit;

            //Debug.Log("チクタク...");
            counterText.text = "<PULSE>";
            uiTimer = defUiTimer;
        }
        else
        {
            isTick = false;
            counter = counter - Time.deltaTime;
        }

        if (uiTimer > 0.0f)
        {
            uiTimer = uiTimer - Time.deltaTime;
        }
        else
        {
            counterText.text = " ";
        }
    }

}

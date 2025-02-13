using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stage : MonoBehaviour
{
    public float waitTimer;
    public static float nowWaitTimer;
    public static float waitInterval = 1.0f;
    public GameObject[] gameObjectUI = new GameObject[2];
    public GameObject[] gameObjectUIStage = new GameObject[2];
    public GameObject[] gameObjectUIStatus = new GameObject[2];
    public GameObject lastTrain;
    public TMP_Text[] tMPText = new TMP_Text[4];
    private bool boolUIResult;

    void Awake()
    {
        nowWaitTimer = waitTimer;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObjectUI[1].SetActive(false);
        gameObjectUIStage[1].SetActive(false);
        gameObjectUIStatus[0].SetActive(false);
        gameObjectUIStatus[1].SetActive(false);
        boolUIResult = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastTrain.transform.position.z < 0.0f)
        {
            int intRemainRange = (int)lastTrain.transform.position.z * -1;

            if (intRemainRange < 10)
            {
                tMPText[2].text = "00" + intRemainRange.ToString() + "m";
            }
            else if (intRemainRange < 100)
            {
                tMPText[2].text = "0" + intRemainRange.ToString() + "m";
            }
            else if (intRemainRange < 1000)
            {
                tMPText[2].text = intRemainRange.ToString() + "m";
            }
        }

        if (nowWaitTimer > waitInterval)
        {
            GamePreparation();
        }
        else if (nowWaitTimer <= waitInterval)
        {
            GameStart();
        }

        if(GenerateObject.nowGenerateNumber < 10)
        {
            tMPText[0].text = "~0" + GenerateObject.nowGenerateNumber;
        }
        else if (GenerateObject.nowGenerateNumber < 100)
        {
            tMPText[0].text = "~" + GenerateObject.nowGenerateNumber;
        }
    }

    void GamePreparation()
    {
        string textMinute, textSecond;

        nowWaitTimer -= Time.deltaTime;

        int minute = (int)nowWaitTimer / 60;
        int second = (int)nowWaitTimer % 60;
        //•ª
        if (minute < 10)
        {
            textMinute = "0" + minute.ToString();
        }
        else
        {
            textMinute = minute.ToString();
        }
        //•b
        if (second < 10)
        {
            textSecond = "0" + second.ToString();
        }
        else
        {
            textSecond = second.ToString();
        }

        tMPText[1].text = textMinute + ":" + textSecond;
    }

    void GameStart()
    {
        if (nowWaitTimer != waitInterval)
        {
            nowWaitTimer = 0.0f;
        }

        gameObjectUIStage[0].SetActive(false);
        gameObjectUIStage[1].SetActive(true);

        if (TrainBase.nowMoveSpeed <= 0.0f)
        {
            GameClear();
        }
        else if (lastTrain.transform.position.z >= 0.0f)
        {
            GameOver();
        }

        float nowMoveSpeed = (int)TrainBase.nowMoveSpeed * 3.6f;

        if(nowMoveSpeed < 10)
        {
            tMPText[3].text = "00" + (int)nowMoveSpeed + "km/h";
        }
        else if (nowMoveSpeed < 100)
        {
            tMPText[3].text = "0" + (int)nowMoveSpeed + "km/h";
        }
        else if (nowMoveSpeed < 1000)
        {
            tMPText[3].text = (int)nowMoveSpeed + "km/h";
        }
    }

    void GameClear()
    {
        gameObjectUIStatus[0].SetActive(true);

        if (boolUIResult == false)
        {
            boolUIResult = true;
            Invoke("UIResult", 3.0f);
        }
    }

    void GameOver()
    {
        gameObjectUIStatus[1].SetActive(true);

        if (boolUIResult == false)
        {
            boolUIResult = true;
            Invoke("UIResult", 3.0f);
        }
    }

    void UIResult()
    {
        gameObjectUI[0].SetActive(false);
        gameObjectUI[1].SetActive(true);
    }
}

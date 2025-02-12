using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stage : SceneBase
{
    public float waitTimer;
    public static bool departure;
    public GameObject trainStopIt;
    public GameObject gameClear;
    public GameObject gameOver;
    public GameObject gameObjectMoveSpeed;
    public GameObject lastTrain;
    public TMP_Text remainTime;
    public TMP_Text remainObject;
    public TMP_Text remainRange;
    private TMP_Text tMPTextMoveSpeed;
    private float waitInterval;

    // Start is called before the first frame update
    void Start()
    {
        LoadScene();

        tMPTextMoveSpeed = gameObjectMoveSpeed.GetComponent<TMP_Text>();

        departure = false;
        gameClear.SetActive(false);
        gameOver.SetActive(false);
        gameObjectMoveSpeed.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(lastTrain.transform.position.z < 0.0f)
        {
            int intRemainRange = (int)lastTrain.transform.position.z * -1;
            remainRange.text = intRemainRange.ToString() + "m";
        }

        if (waitTimer > waitInterval)
        {
            Stop();
        }
        else if (waitTimer <= waitInterval)
        {
            departure = true;
        }

        if (departure == true)
        {
            Departure();
        }

        remainObject.text = "~" + GenerateObject.nowGenerateNumber;
    }

    void Stop()
    {
        string textMinute, textSecond;

        waitTimer -= Time.deltaTime;

        int minute = (int)waitTimer / 60;
        int second = (int)waitTimer % 60;
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

        remainTime.text = textMinute + ":" + textSecond;
    }

    void Departure()
    {
        trainStopIt.SetActive(false);
        gameObjectMoveSpeed.SetActive(true);

        if (TrainBase.nowMoveSpeed <= 0.0f)
        {
            gameClear.SetActive(true);
        }
        else if (lastTrain.transform.position.z >= 0.0f)
        {
            gameOver.SetActive(true);
        }

        float nowMoveSpeed = (int)TrainBase.nowMoveSpeed * 3.6f;
        tMPTextMoveSpeed.text = (int)nowMoveSpeed + "km/h";
    }
}

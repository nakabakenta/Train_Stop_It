using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject gameClear;
    public GameObject gameOver;
    private Transform trainTransform;

    // Start is called before the first frame update
    void Start()
    {
        trainTransform = GameObject.Find("Train").GetComponent<Transform>();

        gameClear.SetActive(false);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (TrainBase.nowMoveSpeed <= 0.0f)
        {
            gameClear.SetActive(true);
        }
        else if(trainTransform.position.z > 0.0f)
        {
            gameOver.SetActive(true);
        }
    }
}

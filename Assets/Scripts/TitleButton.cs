using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public static string selectButton;//選択しているボタン
    private Button button;
    private string[] buttonName
        = new string[6] { "Button_Stage1", "Button_Stage2", "Button_Stage3", "Button_Stage4", "Button_Stage5", "Button_Stage6" };
    private string[] StageName
        = new string[6] { "Stage1", "Stage2", "Stage3", "Stage4", "Stage5", "Stage6" };

    // Start is called before the first frame update
    void Start()
    {
        selectButton = null;
        button = this.GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selectButton = button.gameObject.name;//選択しているボタンの名前を入れる
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < buttonName.Length; i++)
        {
            if(selectButton == buttonName[i])
            {
                SceneManager.LoadScene(StageName[i]);
            }
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageButton : ButtonBase, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public static string selectButton;//選択しているボタン

    private string[] buttonName
        = new string[2] { "Button_Restart", "Button_BackToMenu" };

    // Start is called before the first frame update
    void Start()
    {
        GetComponent();
        selectButton = null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonEnter();
        selectButton = button.gameObject.name;//選択しているボタンの名前を入れる
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ButtonExit();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(selectButton == buttonName[0])
        {
            LoadScene(GameManager.nowScene);
        }
        else if(selectButton == buttonName[1])
        {
            LoadScene("Title");
        }
    }
}

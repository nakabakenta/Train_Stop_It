using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBase : MonoBehaviour
{
    protected Button button;
    protected GameObject gameObjectAlpha;//"GameObject(”¼“§–¾)"

    public void GetComponent()
    {
        button = this.GetComponent<Button>();
        Transform transformAlpha = this.transform.Find("Alpha_UI_Base64");
        gameObjectAlpha = transformAlpha?.gameObject;
    }

    public void ButtonEnter()
    {
        gameObjectAlpha.SetActive(false);
    }

    public void ButtonExit()
    {
        gameObjectAlpha.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        GameManager.nowScene = sceneName;
        SceneManager.LoadScene(GameManager.nowScene);
    }
}

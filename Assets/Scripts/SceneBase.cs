using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBase : MonoBehaviour
{
    public void LoadScene()
    {
        GameManager.nowScene = SceneManager.GetActiveScene().name;
    }
}

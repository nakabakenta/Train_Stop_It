using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBase : MonoBehaviour
{
    public int generateNumber;
    public GameObject gameObjectGenerate;
    protected Transform thisTransform;

    public void GetComponent()
    {
        thisTransform = this.GetComponent<Transform>();
    }
}

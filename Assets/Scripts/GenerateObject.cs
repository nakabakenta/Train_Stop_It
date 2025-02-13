using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObject : GenerateBase
{
    public static int nowGenerateNumber;
    public static bool boolGenerate;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent();
        nowGenerateNumber = generateNumber;
        boolGenerate = true;
    }

    // Update is called once per frame
    void Update()
    {
        Generate();
    }

    void Generate()
    {
        if (nowGenerateNumber > 0 && boolGenerate == true)
        {
            Instantiate(gameObjectGenerate,
               new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
               Quaternion.identity, thisTransform);
            boolGenerate = false;
        }
    }
}

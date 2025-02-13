using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBGM : GenerateBase
{
    public static int nowGenerateNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent();

        if (nowGenerateNumber == 0)
        {
            Instantiate(gameObjectGenerate,
               new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
               Quaternion.identity);
            nowGenerateNumber += 1;
        }
    }
}

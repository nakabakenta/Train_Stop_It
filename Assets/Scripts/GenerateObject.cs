using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObject : GenerateBase
{
    public static int nowGenerateNumber;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent();
        nowGenerateNumber = generateNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if(nowGenerateNumber > 0 && ObjectBase.putObject == true)
        {
            Instantiate(gameObjectGenerate,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                Quaternion.identity, thisTransform);
            ObjectBase.putObject = false;
        }
    }
}

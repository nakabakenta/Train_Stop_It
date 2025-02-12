using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRail : GenerateBase
{
    private float railLength = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent();

        for (int i = 0; i < generateNumber; i++)
        {
            Instantiate(gameObjectGenerate, 
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + railLength), 
                Quaternion.identity, thisTransform);

            Instantiate(gameObjectGenerate,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - railLength),
                Quaternion.identity, thisTransform);

            railLength += 1.0f;
        }
    }
}

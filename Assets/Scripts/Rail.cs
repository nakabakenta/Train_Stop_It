using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    public int generateRail;
    public GameObject gameObjectRail;
    private int railLength = 0;
    private Transform thisTransform;

    // Start is called before the first frame update
    void Awake()
    {
        thisTransform = this.GetComponent<Transform>();

        for (int i = 0; i < generateRail; i++)
        {
            Instantiate(gameObjectRail, 
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + railLength), 
                Quaternion.identity, thisTransform);

            Instantiate(gameObjectRail,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - railLength),
                Quaternion.identity, thisTransform);

            railLength += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

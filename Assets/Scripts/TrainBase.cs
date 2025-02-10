using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBase : MonoBehaviour
{
    public float moveSpeed;
    public static float nowMoveSpeed;

    private Rigidbody[] rigidbodies;
    private BoxCollider[] boxColliders;
    private AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        boxColliders = GetComponentsInChildren<BoxCollider>();
        audioSources = GetComponentsInChildren<AudioSource>();
        nowMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(nowMoveSpeed <= 0.0f)
        {
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                rigidbodies[i].useGravity = true;
            }
        }

        if(this.transform.position.z > 100.0f)
        {
            
        }
        else 
        {
            this.transform.position += nowMoveSpeed * transform.forward * Time.deltaTime;//
        }
    }
}

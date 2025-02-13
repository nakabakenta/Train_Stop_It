using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBase : MonoBehaviour
{
    public float moveSpeed;
    public static float nowMoveSpeed;
    public AudioClip sETrainHorn;

    private bool trainHorn;
    private Rigidbody[] rigidbodies;
    private BoxCollider[] boxColliders;
    private AudioSource[] audioSources;

    private float accelerationInterval = 20.0f;
    private float accelerationTimer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        boxColliders = GetComponentsInChildren<BoxCollider>();
        audioSources = GetComponentsInChildren<AudioSource>();
        nowMoveSpeed = moveSpeed;
        trainHorn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.nowScene == "Title")
        {
            Move();
        }
        else
        {
            if (Stage.nowWaitTimer <= Stage.waitInterval)
            {
                if (this.transform.position.z > 350.0f)
                {

                }
                else
                {
                    if (sETrainHorn != null)
                    {
                        if (trainHorn == false)
                        {
                            audioSources[0].PlayOneShot(sETrainHorn);
                            trainHorn = true;
                        }
                    }

                    if(nowMoveSpeed > 0.0f)
                    {
                        if (accelerationTimer >= accelerationInterval)
                        {
                            if (nowMoveSpeed < moveSpeed)
                            {
                                nowMoveSpeed += 2.0f * Time.deltaTime;
                            }
                        }
                        else
                        {
                            accelerationTimer += Time.deltaTime;
                        }

                        Move();
                    }
                }
            }
        }
    }

    public void Move()
    {
        this.transform.position += nowMoveSpeed * transform.forward * Time.deltaTime;
    }
}
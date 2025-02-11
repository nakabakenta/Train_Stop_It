using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public ClassRange[] range;
    protected Rigidbody rigidBody;            //"Rigidbody"
    protected BoxCollider boxCollider;        //"BoxCollider"
    protected CapsuleCollider capsuleCollider;//
    protected AudioSource audioSource;        //"AudioSource"

    [System.Serializable]
    public class ClassRange
    {
        public Vector3[] moveRange;
    }

    public void GetComponent()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();

        if (this.gameObject.TryGetComponent<BoxCollider>(out boxCollider))
        {
            boxCollider = this.gameObject.GetComponent<BoxCollider>();
        }
        else if(this.gameObject.TryGetComponent<CapsuleCollider>(out capsuleCollider))
        {
            capsuleCollider = this.gameObject.GetComponent<CapsuleCollider>();
        }

        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
}

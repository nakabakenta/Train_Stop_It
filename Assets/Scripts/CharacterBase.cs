using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public ClassRange[] range;
    protected Rigidbody rigidBody;    //"Rigidbody"
    protected BoxCollider boxCollider;//"BoxCollider"
    protected AudioSource audioSource;//"AudioSource"

    [System.Serializable]
    public class ClassRange
    {
        public Vector3[] moveRange;
    }

    public void GetComponent()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        boxCollider = this.gameObject.GetComponent<BoxCollider>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : CharacterBase
{
    public float objectPower;
    public AudioClip sEObject;
    private bool input;
    //���W
    protected Vector3 worldPosition, viewPortPosition, mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent();
        boxCollider.isTrigger = true;
        input = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Stage.nowWaitTimer <= 0.0f)
        {
            input = true;
        }

        if (input == true)
        {
            boxCollider.isTrigger = false;
        }
        else if(input == false)
        {
            //�}�E�X�̈ʒu���擾����
            mousePosition = Input.mousePosition;
            //�}�E�X�̈ʒu(�X�N���[�����W)���r���[�|�C���g���W�ɕϊ�����
            viewPortPosition = Camera.main.ScreenToViewportPoint(new Vector3(mousePosition.x, mousePosition.y, 10.0f));
            //�ړ��̌��E�ʒu��ݒ肷��
            viewPortPosition.x = Mathf.Clamp(viewPortPosition.x, range[0].moveRange[0].x, range[0].moveRange[1].x);
            viewPortPosition.y = Mathf.Clamp(viewPortPosition.y, range[0].moveRange[0].y, range[0].moveRange[1].y);
            //�r���[�|�C���g���W�����[���h���W�ɕϊ�����
            this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewPortPosition.x, viewPortPosition.y, 10.0f));

            rigidBody.velocity = Vector3.zero;

            if (Input.GetMouseButtonDown(0))
            {
                input = true;
                GenerateObject.nowGenerateNumber -= 1;
                GenerateObject.boolGenerate = true;
            }
        }
    }

    //�����蔻��(OnCollisionEnter)
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Train")
        {
            rigidBody.AddForce(Vector3.forward * TrainBase.nowMoveSpeed / 2, ForceMode.Impulse);

            if (TrainBase.nowMoveSpeed > 0.0f)
            {
                TrainBase.nowMoveSpeed -= objectPower;
                audioSource.PlayOneShot(sEObject);
            }
        }
    }
}

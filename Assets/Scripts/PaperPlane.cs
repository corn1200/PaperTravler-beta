using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlane : MonoBehaviour
{
    public float jumpPower;
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }
}

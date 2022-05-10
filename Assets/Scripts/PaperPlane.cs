using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlane : MonoBehaviour
{
    public float jumpPower;
    public float maxVelocitySpeed;
    public float maxRotateSpeed;
    public float maxRotateX = 20;
    public float minRotateX = 10;
    public float maxRotateY = 40;
    public float minRotateY = -40;
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddRelativeForce(new Vector3(0, 0, v), ForceMode.Impulse);
        rigid.AddRelativeTorque(new Vector3(0, h, 0) * maxRotateSpeed, ForceMode.Impulse);

        rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, maxVelocitySpeed);

        float rotX = transform.rotation.eulerAngles.x + (maxRotateSpeed * Time.deltaTime) * (-h);

        float rotY = transform.rotation.eulerAngles.y + (maxRotateSpeed * Time.deltaTime) * h;


        if (rotX > maxRotateX) { rotX = maxRotateX; }

        if (rotX < minRotateX) { rotX = minRotateX; }

        if (rotY > maxRotateY) { rotY = maxRotateY; }

        if (rotY < minRotateY) { rotY = minRotateY; }
    }
}

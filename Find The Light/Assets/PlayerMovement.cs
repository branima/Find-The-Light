using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public DynamicJoystick joystickScript;

    public float speed;

    public Rigidbody rb;

    Vector3 direction;

    void FixedUpdate()
    {

        float hor = joystickScript.Horizontal;
        float ver = joystickScript.Vertical;
        direction = new Vector3(hor, 0, ver);

        //transform.Translate(direction * Time.deltaTime * speed * 5f);
        rb.MovePosition(transform.position + direction * Time.fixedDeltaTime * speed * 5f);
    }
}

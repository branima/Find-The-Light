using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerLightControl : MonoBehaviour
{

    public float speed;

    public Rigidbody rb;

    Vector3 direction;

    void FixedUpdate()
    {

        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                direction = new Vector3(hit.point.x - transform.position.x, 0f, hit.point.z - transform.position.z).normalized;
        }
        else
            direction = Vector3.zero;

        //transform.Translate(direction * Time.deltaTime * speed * 5f);
        rb.MovePosition(transform.position + direction * Time.fixedDeltaTime * speed * 5f);

        //Vector3 lookAtPos = transform.position + direction;
        //transform.LookAt(lookAtPos);
    }
}

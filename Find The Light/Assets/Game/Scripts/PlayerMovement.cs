using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public DynamicJoystick joystickScript;

    public float speed;

    public Rigidbody rb;

    public Animator playerAnimator;

    Vector3 direction;

    public AudioSource audioSource;

    void OnDisable()
    {
        playerAnimator.SetBool("boolWalk", false);
        AudioManager.Instance.Stop("walk");
    }
    void FixedUpdate()
    {

        float hor = joystickScript.Horizontal;
        float ver = joystickScript.Vertical;
        direction = new Vector3(hor, 0, ver);

        if (direction != Vector3.zero)
        {
            playerAnimator.SetBool("boolWalk", true);
            if (!AudioManager.Instance.IsPlaying("walk"))
                AudioManager.Instance.Play(audioSource, "walk");
        }
        else
        {
            playerAnimator.SetBool("boolWalk", false);
            AudioManager.Instance.Stop("walk");
        }
        //transform.Translate(direction * Time.deltaTime * speed * 5f);
        rb.MovePosition(transform.position + direction * Time.fixedDeltaTime * speed * 5f);

        Vector3 lookAtPos = transform.position + direction.normalized;
        transform.LookAt(lookAtPos);
    }
}

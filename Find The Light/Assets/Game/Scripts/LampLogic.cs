using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLogic : MonoBehaviour
{

    public Transform player;
    public Animator lightAnimator;

    bool litUp;

    RaycastHit hit;

    public AudioSource audioSource;

    void Start() => player = GameManager.Instance.GetPlayer();

    void Update()
    {
        if (Physics.Raycast(transform.position, player.position - transform.position, out hit))
        {
            if (hit.transform == player && !litUp)
            {
                litUp = true;
                lightAnimator.SetTrigger("lightUpTrigger");
                GameLoop.Instance.AddActiveLamp();
                AudioManager.Instance.Play(audioSource, "glowUp1");
                //AudioManager.Instance.Play(audioSource, "glowUp2");   
            }
            else if (litUp && hit.transform != player)
            {
                litUp = false;
                lightAnimator.SetTrigger("lightDownTrigger");
                GameLoop.Instance.RemoveActiveLamp();
            }
        }
    }
}

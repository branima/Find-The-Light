using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{

    public List<Animator> obstacles;

    public float speed;

    public Animator buttonAnimator;

    bool downing;

    public AudioSource audioSource;

    void Update()
    {
        if (!downing)
            return;

        foreach (Animator item in obstacles)
            item.transform.position = item.transform.position - Vector3.up * Time.deltaTime * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        AudioManager.Instance.Play(audioSource, "switch");

        buttonAnimator.SetBool("pushedDown", true);
        downing = true;

        foreach (Animator item in obstacles)
            item.SetBool("sinking", true);
    }

    void OnTriggerStay(Collider other)
    {
        if (!AudioManager.Instance.IsPlaying("rumble"))
            AudioManager.Instance.Play("rumble");
    }

    void OnTriggerExit(Collider other)
    {
        AudioManager.Instance.Play(audioSource, "switch");
        AudioManager.Instance.Stop("rumble");

        buttonAnimator.SetBool("pushedDown", false);
        downing = false;

        foreach (Animator item in obstacles)
            item.SetBool("sinking", false);
    }
}

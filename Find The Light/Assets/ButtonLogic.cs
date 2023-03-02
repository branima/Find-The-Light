using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{

    public List<Animator> obstacles;

    public float speed;

    public Animator buttonAnimator;

    bool downing;

    void Update()
    {
        if (!downing)
            return;

        foreach (Animator item in obstacles)
            item.transform.position = item.transform.position - Vector3.up * Time.deltaTime * speed;
    }

    void OnTriggerStay(Collider other)
    {
        buttonAnimator.SetBool("pushedDown", true);
        downing = true;

        foreach (Animator item in obstacles)
            item.SetBool("sinking", true);
    }

    void OnTriggerExit(Collider other)
    {
        buttonAnimator.SetBool("pushedDown", false);
        downing = false;

        foreach (Animator item in obstacles)
            item.SetBool("sinking", false);
    }
}

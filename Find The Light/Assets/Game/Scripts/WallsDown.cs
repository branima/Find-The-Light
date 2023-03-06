using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsDown : MonoBehaviour
{
    public Transform obstaclesParent;

    public float speed;

    public Animation lightOutAnimation;

    void Start() => lightOutAnimation.Play();

    void Update()
    {
        foreach (Transform item in obstaclesParent)
            item.position = item.position - Vector3.up * Time.deltaTime * speed;
    }
}

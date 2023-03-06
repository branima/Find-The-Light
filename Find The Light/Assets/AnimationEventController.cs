using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventController : MonoBehaviour
{

    public static AnimationEventController Instance;
    void Awake() => Instance = this;

    public void EnableLevelCompleteUI() => GameManager.Instance.LevelComplete();

    public void StampSound() => AudioManager.Instance.Play("slap");
}

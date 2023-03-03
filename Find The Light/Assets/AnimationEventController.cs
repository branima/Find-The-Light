using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventController : MonoBehaviour
{

    public void EnableLevelCompleteUI() => GameManager.Instance.LevelComplete();
}

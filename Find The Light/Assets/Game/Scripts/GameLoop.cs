using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{

    int numOfActiveLamps;
    public Transform lampParent;

    public GameObject lightLines;

    public WallsDown wallsDownScript;

    public GameObject floorSticker;

    public static GameLoop Instance;
    void Awake() => Instance = this;

    void Start() => numOfActiveLamps = 0;

    public void AddActiveLamp() => ChangeActiveLampCount(1);
    public void RemoveActiveLamp() => ChangeActiveLampCount(-1);
    void ChangeActiveLampCount(int value)
    {
        numOfActiveLamps += value;
        if (numOfActiveLamps == lampParent.childCount)
        {
            GameManager.Instance.GetPlayer().GetComponent<PlayerMovement>().enabled = false;
            CameraSwitch.Instance.ChangeCamera();
            lightLines.SetActive(true);
            wallsDownScript.enabled = true;

            if (floorSticker != null)
                foreach (Transform item in lampParent)
                    item.GetComponent<Animator>().SetTrigger("lightDownTrigger");
        }
    }

    public bool EnableSticker()
    {
        if (floorSticker != null)
        {
            floorSticker.SetActive(true);
            return true;
        }
        else
            Invoke("LevelComplete", 1f);

        return false;
    }

    void LevelComplete() => AnimationEventController.Instance.EnableLevelCompleteUI();
}

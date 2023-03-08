using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousePosition : MonoBehaviour
{
    public Image cursor;
    public Image cursorPressed;
    [SerializeField]
    bool isPressed;

    public float cameraToCanvasDistance;

    bool show;

    public Camera cam;

    bool autoClick;
    float autoClickInterval;
    float lastTImeClicked;
    int lastClickFrame;

    void Start()
    {
        show = false;
        autoClick = false;
    }

    private void LateUpdate()
    {
        if (autoClick)
            AutoClick();
        else
        {

            if (Input.GetKeyDown(KeyCode.Space))
                show = !show;

            if (Input.GetMouseButtonDown(0))
                isPressed = true;

            if (Input.GetMouseButtonUp(0))
                isPressed = false;

            if (isPressed && show)
            {
                cursor.gameObject.SetActive(false);
                cursorPressed.gameObject.SetActive(true);
            }
            else if (!isPressed && show)
            {
                cursor.gameObject.SetActive(true);
                cursorPressed.gameObject.SetActive(false);
            }
            else
            {
                cursor.gameObject.SetActive(false);
                cursorPressed.gameObject.SetActive(false);
            }
        }

        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = cameraToCanvasDistance; //distance of the plane from the camera
        cursor.gameObject.transform.position = cam.ScreenToWorldPoint(screenPoint);
        cursorPressed.gameObject.transform.position = cam.ScreenToWorldPoint(screenPoint);
    }

    void AutoClick()
    {
        if (Time.time - lastTImeClicked > autoClickInterval)
        {
            cursor.gameObject.SetActive(false);
            cursorPressed.gameObject.SetActive(true);
            lastTImeClicked = Time.time;
            lastClickFrame = Time.frameCount;
        }

        else if (Time.frameCount - lastClickFrame > 20)
        {
            cursor.gameObject.SetActive(true);
            cursorPressed.gameObject.SetActive(false);
        }

    }

    public void EnableAutoClick(float autoClickInterval)
    {
        autoClick = true;
        this.autoClickInterval = autoClickInterval;
        lastTImeClicked = Mathf.NegativeInfinity;
        lastClickFrame = 0;
    }
}
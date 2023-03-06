using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSetup : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public List<Transform> linePoints;
    List<Vector3> convertedPoints;

    public Animation lightAnimation;

    int currPointIdx;
    Vector3 targetPos;
    float lerpTime;
    public float speed;

    public AudioSource audioSource;

    void Start()
    {
        convertedPoints = new List<Vector3>();
        for (int i = 0; i < linePoints.Count; i++)
            convertedPoints.Add(linePoints[i].position);

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, convertedPoints[0]);
        currPointIdx = 1;
        targetPos = convertedPoints[currPointIdx];
        convertedPoints[currPointIdx] = convertedPoints[currPointIdx - 1];
        lineRenderer.SetPosition(currPointIdx, convertedPoints[currPointIdx]);
        AudioManager.Instance.Play(audioSource, "laser");
    }

    void Update()
    {
        if (currPointIdx == linePoints.Count)
            return;

        lerpTime += Time.deltaTime * speed;
        //convertedPoints[currPointIdx] = Vector3.Lerp(convertedPoints[currPointIdx], targetPos, lerpTime);
        convertedPoints[currPointIdx] = Vector3.MoveTowards(convertedPoints[currPointIdx], targetPos, Time.deltaTime * speed * 25f);
        lineRenderer.SetPosition(currPointIdx, convertedPoints[currPointIdx]);

        if (Vector3.Distance(convertedPoints[currPointIdx], targetPos) < 0.01f)
        {
            convertedPoints[currPointIdx] = targetPos;
            currPointIdx++;
            lerpTime = 0f;

            if (currPointIdx == linePoints.Count)
            {
                if (GameLoop.Instance.EnableSticker())
                    TurnOffLights();
                return;
            }

            targetPos = convertedPoints[currPointIdx];
            convertedPoints[currPointIdx] = convertedPoints[currPointIdx - 1];
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(currPointIdx, convertedPoints[currPointIdx]);
            AudioManager.Instance.Play(audioSource, "laser");
        }
    }

    void TurnOffLights() => lightAnimation.Play("Turn Off Yellow");
}

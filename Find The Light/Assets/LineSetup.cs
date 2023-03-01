using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSetup : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public List<Transform> linePoints;

    void Start()
    {
        lineRenderer.positionCount = linePoints.Count;
        for (int i = 0; i < linePoints.Count; i++)
            lineRenderer.SetPosition(i, linePoints[i].position);
    }
}

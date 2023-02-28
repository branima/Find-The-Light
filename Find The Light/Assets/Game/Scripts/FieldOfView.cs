using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    [SerializeField] LayerMask layerMask;
    Mesh mesh;
    float fov;
    [SerializeField] float viewDistance;
    [SerializeField] int rayCount;
    float startingAngle;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 360f;

        LightBake();
    }

    void LightBake()
    {
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = Vector3.zero;
        //Debug.Log(vertices[0]);

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, GetVectorFromAngle(angle), out hit, viewDistance, layerMask))
                vertex = hit.point;
            else
                vertex = transform.position + GetVectorFromAngle(angle) * viewDistance;

            //Debug.DrawRay(transform.position, GetVectorFromAngle(angle) * Vector3.Distance(transform.position, vertex));
            vertices[vertexIndex] = vertex - transform.position;
            //Debug.Log(vertices[vertexIndex]);

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(transform.position, Vector3.one * 1000f);
    }

    Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), 0f, Mathf.Sin(angleRad));
    }
}

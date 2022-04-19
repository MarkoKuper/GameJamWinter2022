using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class FieldOfView : MonoBehaviour
{
    private Mesh mesh;
    [SerializeField] private LayerMask layerMask;
    private Vector3 origin;
    private float startingAngle;
    private float fov;
    private void Start()
    {
        transform.position += new Vector3(-transform.parent.position.x, -transform.parent.position.y, 0f);

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
        fov = 90f;

    }

    private void LateUpdate()
    {
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 50f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangle = new int[rayCount * 3];


        vertices[0] = origin;
        
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = raycastHit2D.point;
            }

            vertices[vertexIndex] = vertex;
            if (i > 0)
            {
                triangle[triangleIndex + 0] = 0;
                triangle[triangleIndex + 1] = vertexIndex - 1;
                triangle[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;

            angle -= angleIncrease;
        }

        triangle[0] = 0;
        triangle[1] = 1;
        triangle[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangle;
    }
    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }
    public void SetAimDirection (Vector3 aimDirection)
    {
        startingAngle = UtilsClass.GetAngleFromVectorFloat(aimDirection) - fov / 2f;
    }
}

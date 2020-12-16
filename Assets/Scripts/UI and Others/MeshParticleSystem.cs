using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshParticleSystem : MonoBehaviour
{
    private const int MAX_QUAD_AMOUNT = 15000;
    Mesh mesh = new Mesh();

    Vector3[] vertices;
    Vector2[] uv;
    int[] triangles;

    private int quadIndex;

    // Start is called before the first frame update
    void Awake()
    {
        vertices = new Vector3[4 * MAX_QUAD_AMOUNT];
        uv = new Vector2[4 * MAX_QUAD_AMOUNT];
        triangles = new int[6 * MAX_QUAD_AMOUNT];

        AddQuad(new Vector3(0,0));
        AddQuad(new Vector3(0, 5));

        vertices[0] = new Vector3(0, 0);
        vertices[1] = new Vector3(0, 100);
        vertices[2] = new Vector3(100, 100);
        vertices[3] = new Vector3(100, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        uv[0] = new Vector2(0,0);
        uv[1] = new Vector2(0,1);
        uv[2] = new Vector2(1,1);
        uv[3] = new Vector2(1,0);

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddQuad(Vector3 position)
    {
        if (quadIndex >= MAX_QUAD_AMOUNT) return; //Mesh Full
        //Relocate Vertices
        int vIndex = quadIndex * 4;
        int vIndex0 = vIndex;
        int vIndex1 = vIndex + 1;
        int vIndex2 = vIndex + 2;
        int vIndex3 = vIndex + 3;

        Vector3 quadSize = new Vector3(1, 1);
        float rotation = 0f;
        vertices[vIndex0] = position + Quaternion.Euler(0, 0, rotation - 180) * quadSize;
        vertices[vIndex1] = position + Quaternion.Euler(0, 0, rotation - 270) * quadSize;
        vertices[vIndex2] = position + Quaternion.Euler(0, 0, rotation - 0) * quadSize;
        vertices[vIndex3] = position + Quaternion.Euler(0, 0, rotation - 90) * quadSize;

        //Create Triangles
        int tIndex = quadIndex * 6;

        triangles[tIndex + 0] = vIndex0;
        triangles[tIndex + 1] = vIndex1;
        triangles[tIndex + 2] = vIndex2;

        triangles[tIndex + 3] = vIndex0;
        triangles[tIndex + 4] = vIndex2;
        triangles[tIndex + 5] = vIndex3;

        quadIndex++;
    }
}

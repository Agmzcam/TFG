using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour {

    private float thickness = 0.1f; //grosor de la línea
    private Vector3 a, b, c, d;
    private Vector3 lineDir; //dirección de la línea
    private Vector3 ortogonalLineDir; //vector ortogonal a la línea dibujada

    public void CalculateVertexMexh (Vector3 start, Vector3 end)
    {
        a = start + ortogonalLineDir * thickness * 0.5f;
        b = start - ortogonalLineDir * thickness * 0.5f;
        c = end + ortogonalLineDir * thickness * 0.5f;
        d = end - ortogonalLineDir * thickness * 0.5f;

    }

    public void AddLineSegmentToDrawMesh (Mesh currentMesh, Vector3 start, Vector3 end)
    {
        lineDir = end - start;
        ortogonalLineDir = new Vector3(-lineDir.y, lineDir.x, lineDir.z).normalized;
        if (lineDir.sqrMagnitude < 0.0001f)
        {
            return;
        }

        Vector3[] vertexList = currentMesh.vertices;
        int vertexListLenght = vertexList.Length;
        Vector3[] newVertexList;
        if (vertexListLenght == 0)
        {
            newVertexList = new Vector3[vertexListLenght + 4];
        }
        else
            newVertexList = new Vector3[vertexListLenght + 2];

        for (int i = 0; i < vertexListLenght; i++)
        {
            newVertexList[i] = vertexList[i];
        }
        if (vertexListLenght != 0)
        {
            vertexListLenght -= 2;
        }

        newVertexList[vertexListLenght] = start + ortogonalLineDir * thickness * 0.5f;
        newVertexList[vertexListLenght + 1] = start - ortogonalLineDir * thickness * 0.5f;
        newVertexList[vertexListLenght + 2] = end + ortogonalLineDir * thickness * 0.5f;
        newVertexList[vertexListLenght + 3] = end - ortogonalLineDir * thickness * 0.5f;

        int[] triangleList = currentMesh.triangles;
        int triangleListLength = triangleList.Length;
        int[] newTriangleList = new int[triangleListLength + 6];
        for (int i = 0; i < triangleListLength; i++) {
            newTriangleList[i] = triangleList[i];
        }
        newTriangleList[triangleListLength] = vertexListLenght;     //a
        newTriangleList[triangleListLength + 1] = vertexListLenght + 1; //b
        newTriangleList[triangleListLength + 2] = vertexListLenght + 2; //c
        newTriangleList[triangleListLength + 3] = vertexListLenght + 1; //b
        newTriangleList[triangleListLength + 4] = vertexListLenght + 3; //d
        newTriangleList[triangleListLength + 5] = vertexListLenght + 2; //c

        currentMesh.Clear();
        currentMesh.vertices = newVertexList;
        currentMesh.triangles = newTriangleList;
    }
}

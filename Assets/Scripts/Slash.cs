using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    [SerializeField] private GameObject _tip,_base;
    [SerializeField] private GameObject _trailMesh;
    [SerializeField] private int _trailFrameLength;

    private Mesh _mesh;
    private Vector3[] _vertices;
    private int[] _triangles;
    private int _frameCount;
    private Vector3 _previousTipPos, _previousBasePos;
    private const int NUM_VERTICES = 12;

    private void Start()
    {
        _mesh = new Mesh();
        _trailMesh.GetComponent<MeshFilter>().mesh = _mesh;
        _vertices = new Vector3[_trailFrameLength * NUM_VERTICES];
        _triangles = new int[_vertices.Length];

        _previousTipPos = _tip.transform.position;
        _previousBasePos = _base.transform.position;
    }
    private void Update()
    {
        if(_frameCount == (_trailFrameLength * NUM_VERTICES))
        {
            _frameCount = 0;
        }
        _vertices[_frameCount] = _base.transform.position;
        _vertices[_frameCount + 1] = _tip.transform.position;
        _vertices[_frameCount + 2] = _previousTipPos;

        _vertices[_frameCount + 3] = _base.transform.position;
        _vertices[_frameCount + 4] = _previousTipPos;
        _vertices[_frameCount + 5] = _tip.transform.position;

        _vertices[_frameCount + 6] = _previousTipPos;
        _vertices[_frameCount + 7] = _base.transform.position;
        _vertices[_frameCount + 8] = _previousBasePos;

        _vertices[_frameCount + 9] = _previousTipPos;
        _vertices[_frameCount + 10] = _previousBasePos;
        _vertices[_frameCount + 11] = _base.transform.position;

        _triangles[_frameCount] = _frameCount;
        _triangles[_frameCount + 1] = _frameCount + 1;
        _triangles[_frameCount + 2] = _frameCount + 2;
        _triangles[_frameCount + 3] = _frameCount + 3;
        _triangles[_frameCount + 4] = _frameCount + 4;
        _triangles[_frameCount + 5] = _frameCount + 5;
        _triangles[_frameCount + 6] = _frameCount + 6;
        _triangles[_frameCount + 7] = _frameCount + 7;
        _triangles[_frameCount + 8] = _frameCount + 8;
        _triangles[_frameCount + 9] = _frameCount + 9;
        _triangles[_frameCount + 10] = _frameCount + 10;
        _triangles[_frameCount + 11] = _frameCount + 11;

        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;

        _previousTipPos = _tip.transform.position;
        _previousBasePos = _base.transform.position;

        _frameCount += NUM_VERTICES;
    }
}

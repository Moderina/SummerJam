using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Material ropeMat;
    public Transform target;
    private LineRenderer lineRenderer;
    private int segmentCount = 2;

    void Awake() {
        this.lineRenderer = this.gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = ropeMat;
    }

    void Start()
    {
        Vector3 ropeStartPoint = this.transform.position;
    }
    void Update()
    {
        this.DrawRope();
    }

    private void DrawRope() {
        float lineWidth = 0.02f;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[this.segmentCount];

        ropePositions[0] = this.transform.position;
        ropePositions[1] = target.position;

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }
}

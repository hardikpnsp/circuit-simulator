using UnityEngine;

public class Wire : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public ConnectionPoint startConnectionPoint;
    public ConnectionPoint endConnectionPoint;
    public bool render = false;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 3;
    }
    void Update()
    {
        if (render)
        {
            Vector3 startPos = startConnectionPoint.transform.position;
            Vector3 endPos = endConnectionPoint.transform.position;
            Vector3 middlePoint = new Vector3(startPos.x, endPos.y);
            Vector3[] pos = { startPos, middlePoint, endPos };
            lineRenderer.SetPositions(pos);
        }
    }

    public void Register()
    {
        startConnectionPoint.RegisterWire(this);
        endConnectionPoint.RegisterWire(this);
        render = true;
    }

    public void DeRegister()
    {
        render = false;
        startConnectionPoint.DeRegisterWire();
        endConnectionPoint.DeRegisterWire();
        Destroy(gameObject);
    }
}

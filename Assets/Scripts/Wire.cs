using UnityEngine;

public class Wire : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public ConnectionPoint startConnectionPoint;
    public ConnectionPoint endConnectionPoint;
    public bool render;

    private void Start()
    {
        render = false;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; 
    }
    void Update()
    {
        if (render)
        {
            Vector3 stratPos = startConnectionPoint.transform.position;
            Vector3 endPos = endConnectionPoint.transform.position;
            Vector3[] pos = { stratPos, endPos };
            lineRenderer.SetPositions(pos);
        }
    }

    void Register()
    {
        render = true;
        startConnectionPoint.RegisterWire(this);
        endConnectionPoint.RegisterWire(this);
    }

    void DeRegister()
    {
        render = false;
        startConnectionPoint.DeRegisterWire();
        endConnectionPoint.DeRegisterWire();
        Destroy(gameObject);
    }
}

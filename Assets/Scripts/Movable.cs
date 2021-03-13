using UnityEngine;

public class Movable : MonoBehaviour
{
    private bool selected;
    private Vector3 offset;

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = transform.position - mousePos;
        }
    }

    public void OnMouseUp()
    {
        selected = false;
    }

    void Update()
    {
        if (selected)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos + offset;
        }
    }
}

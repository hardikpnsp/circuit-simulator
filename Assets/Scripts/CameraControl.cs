using System;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Camera mainCamera;
    float zoom = 8f;
    float zoomSpeed = 50f;
    float moveSpeed = 5f;
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        UpdateZoom();
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            mainCamera.transform.position += Vector3.up * moveSpeed * zoom * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            mainCamera.transform.position += Vector3.down * moveSpeed * zoom * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            mainCamera.transform.position += Vector3.left * moveSpeed * zoom * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            mainCamera.transform.position += Vector3.right * moveSpeed * zoom * Time.deltaTime;
        }
    }

    private void UpdateZoom()
    {
        if (Input.mouseScrollDelta.y > 0f)
        {
            zoom -= zoomSpeed * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y < 0f)
        {
            zoom += zoomSpeed * Time.deltaTime;
        }
        zoom = Mathf.Clamp(zoom, 3f, 40f);
        mainCamera.orthographicSize = zoom;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform TransformOfPIV;
    public Vector3 Offset;

    int travel;
    int scrollSpeed = 3;

    void Update()
    {
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f && travel > -4)
        {
            travel = travel - scrollSpeed;
            Camera.main.transform.Translate(0, 0, 1 * scrollSpeed, Space.Self);
        }
        else if (d < 0f && travel < 20)
        {
            travel = travel + scrollSpeed;
            Camera.main.transform.Translate(0, 0, -1 * scrollSpeed, Space.Self);
        }
    }
}
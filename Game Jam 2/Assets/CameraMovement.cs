using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float boundX;
    public float boundY;
    private Vector2 mousePos;
    float speed = 0.1f;

    // Use this for initialization
    void Start()
    {
        boundX = Screen.width - 30;
        boundY = Screen.height - 30;
        Debug.Log(Input.mousePosition);
        Debug.Log(boundX);
        Debug.Log(boundY);
    }

    void Update()
    {
        mousePos = Input.mousePosition;
        if (mousePos.x > boundX)
        {
            transform.position += new Vector3(speed,0.0f, 0.0f);
        }
        else if (mousePos.x < 30)
        {
            transform.position -= new Vector3(speed, 0.0f, 0.0f);
        }
        else if (mousePos.y > boundY)
        {
            transform.position += new Vector3(0.0f,0.0f, speed);
        }
        else if (mousePos.y < 30)
        {
            transform.position -= new Vector3(0.0f, 0.0f, speed);
        }
        transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * 5);
    }
}

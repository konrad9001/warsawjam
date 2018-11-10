using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speed = 350f;
    [SerializeField] Rigidbody rb;
    [SerializeField] Camera cam;

    public void Move()
    {
        GetPlayerMove();
    }

    void GetPlayerMove()
    {
         MoveCamera();
    }

    void MoveCamera()
    {
        LookLeftRight();
        LookUpDown();
    }

    void LookLeftRight()
    {
        float yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRotation, 0f) * speed * Time.deltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    }

    void LookUpDown()
    {
        float xRotation = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(xRotation * speed * Time.deltaTime, 0f, 0f) ;
        cam.transform.Rotate(-cameraRotation);

        Vector3 clampedRotation = cam.transform.eulerAngles;
        if (clampedRotation.x > 30f && clampedRotation.x < 40f)
        {
            clampedRotation.x = 30f;
            cam.transform.rotation = Quaternion.Euler(clampedRotation);
        }
        else if (clampedRotation.x < 330f && clampedRotation.x > 320f)
        {
            clampedRotation.x = 330f;
            cam.transform.rotation = Quaternion.Euler(clampedRotation);
        }
            
        

    }
}

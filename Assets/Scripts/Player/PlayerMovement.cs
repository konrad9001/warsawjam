using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 350f;
    [SerializeField] Rigidbody playerRigidbody;
    [SerializeField] Camera mainCamera;

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
        playerRigidbody.MoveRotation(playerRigidbody.rotation * Quaternion.Euler(rotation));
    }

    void LookUpDown()
    {
        float xRotation = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(xRotation * speed * Time.deltaTime, 0f, 0f) ;
        mainCamera.transform.Rotate(-cameraRotation);
        CheckCameraRotationLimits();
    }

    void CheckCameraRotationLimits()
    {
        Vector3 clampedRotation = mainCamera.transform.eulerAngles;
        if (IsDownLimitRaised(clampedRotation))
        {
            LockDownRotation(clampedRotation);
        }
        else if (IsUpLimitRaised(clampedRotation))
        {
            LockUpRotation(clampedRotation);
        }
    }

    bool IsDownLimitRaised(Vector3 clampedRotation)
    {
        return clampedRotation.x > 30f && clampedRotation.x < 40f;
    }

    void LockDownRotation(Vector3 clampedRotation)
    {
        clampedRotation.x = 30f;
        mainCamera.transform.rotation = Quaternion.Euler(clampedRotation);
    }

    bool IsUpLimitRaised(Vector3 clampedRotation)
    {
        return clampedRotation.x < 330f && clampedRotation.x > 320f;
    }

    void LockUpRotation(Vector3 clampedRotation)
    {
        clampedRotation.x = 330f;
        mainCamera.transform.rotation = Quaternion.Euler(clampedRotation);
    }
}

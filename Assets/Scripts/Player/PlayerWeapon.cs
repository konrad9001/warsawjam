using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    [SerializeField] Shotgun shotgun;
    [SerializeField] NegativeCamera negativeCamera;

    public void ChangeWeapon()
    {
        if (IsPlayerChangingWeapon())
        {
            ChangeCurrentWeapon();
        }
    }

    void ChangeCurrentWeapon()
    {
        if (IsShotgunActive())
        {
            ActivateCamera();
        }
        else if(IsCameraActive())
        {
            ActivateShotgun();
        }
    }

    bool IsPlayerChangingWeapon()
    {
        return Input.GetAxis("Mouse ScrollWheel") != 0;
    }

    bool IsShotgunActive()
    {
        return shotgun.IsShotgunActive();
    }

    bool IsCameraActive()
    {
        return negativeCamera.IsCameraActive();
    }

    void ActivateCamera()
    {
        shotgun.DeactivateShotgun();
        negativeCamera.ActivateCamera();
    }

    void ActivateShotgun()
    {
        shotgun.ActivateShotgun();
        negativeCamera.DeactiveCamera();
    }
}

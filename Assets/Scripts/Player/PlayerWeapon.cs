using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    [SerializeField] Shotgun shotgun;
    [SerializeField] NegativeCamera negativeCamera;
    [SerializeField] PlayerShooting playerShooting;
    Weapon currentWeapon;

    private void Start()
    {
        currentWeapon = shotgun;
    }

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

    public bool IsShotgunActive()
    {
        return shotgun.IsShotgunActive();
    }

    public bool IsCameraActive()
    {
        return negativeCamera.IsCameraActive();
    }

    void ActivateCamera()
    {
        currentWeapon = negativeCamera;
        shotgun.DeactivateShotgun();
        negativeCamera.ActivateCamera();
    }

    void ActivateShotgun()
    {
        currentWeapon = shotgun;
        shotgun.ActivateShotgun();
        negativeCamera.DeactiveCamera();
    }

    public Shotgun GetShotgun()
    {
        return shotgun;
    }

    public NegativeCamera GetCamera()
    {
        return negativeCamera;
    }

    public string GetWieldedWeapon()
    {
        return currentWeapon.NameOfTheWeapon();
    }
}

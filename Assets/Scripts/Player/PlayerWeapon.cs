using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    [SerializeField] Shotgun shotgun;
    [SerializeField] NegativeCamera negativeCamera;
    [SerializeField] PlayerShooting playerShooting;
    [SerializeField] GameObject crosshair;
    [SerializeField] Animator negativeCameraAnimator;
    [SerializeField] Animator shotgunAnimator;
    Weapon currentWeapon;
    public bool changingWeapon = false;

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
        StartCoroutine(CameraON());
    }

    void ActivateShotgun()
    {
        StartCoroutine(ShotgunON());
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

    public IEnumerator CameraON()
    {
        changingWeapon = true;
        negativeCamera.gameObject.SetActive(true);
        crosshair.SetActive(false);
        shotgunAnimator.SetBool(Keys.WeaponsAnimations.ON, false);
        yield return new WaitForSeconds(0.533f);
        negativeCameraAnimator.SetBool(Keys.WeaponsAnimations.ON, true);
        yield return new WaitForSeconds(0.8f);
        currentWeapon = negativeCamera;
        shotgun.DeactivateShotgun();
        negativeCamera.ActivateCamera();
        changingWeapon = false;
    }

    public IEnumerator ShotgunON()
    {
        changingWeapon = true;
        negativeCamera.DeactiveCamera();
        currentWeapon = shotgun;
        negativeCameraAnimator.SetBool(Keys.WeaponsAnimations.ON, false);
        yield return new WaitForSeconds(1.1f);
        shotgunAnimator.SetBool(Keys.WeaponsAnimations.ON, true);
        yield return new WaitForSeconds(0.533f);
        shotgun.ActivateShotgun();
        crosshair.SetActive(true);
        changingWeapon = false;
    }
}

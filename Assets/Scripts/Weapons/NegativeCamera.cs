using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeCamera : Weapon {

    int remainingSpace = 5;
    bool isActive = true;
    [SerializeField] GameObject negativeEffect;
    [SerializeField] GameObject cameraUI;
    public void SetCameraSpace(int value)
    {
        remainingSpace = value;
    }

    public void ActivateCamera()
    {
        isActive = true;
        cameraUI.SetActive(true);
        ActivateNegativeEffect();
    }

    void ActivateNegativeEffect()
    {
        negativeEffect.gameObject.SetActive(true);
    }

    public void DeactiveCamera()
    {
        isActive = false;
        cameraUI.SetActive(false);
        DeactivateNegativeEffect();
    }

    void DeactivateNegativeEffect()
    {
        negativeEffect.gameObject.SetActive(false);
    }

    public bool IsCameraActive()
    {
        return isActive;
    }

    public void TakePhoto()
    {
        if (remainingSpace > 0)
        {
            remainingSpace -= 1;
            Debug.Log("Photo taken");
        }   
        else
            Debug.Log("Not enough space on camera!");
    }

    public override string NameOfTheWeapon()
    {
        return Keys.Weapons.CAMERA;
    }

    public override void Shoot()
    {
        TakePhoto();
    }

}

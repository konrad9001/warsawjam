using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NegativeCamera : Weapon {

    int photosTaken = 0;
    int photosToCompleteChallange = 7;
    float cameraReloadTime = 7f;
    bool isActive = true;
    [SerializeField] GameObject negativeEffect;
    [SerializeField] GameObject cameraUI;
    [SerializeField] Text counter;
    [SerializeField] Text timer;

    public void ActivateCamera()
    {
        isActive = true;
        cameraUI.SetActive(true);
        ActivateNegativeEffect();
    }

    public override void UpdateTimer()
    {
        cameraReloadTime -= Time.deltaTime;
        timer.text = string.Format("{0:00.00}", cameraReloadTime);
        if (cameraReloadTime < 0)
        {
            timer.text = "Ready!";
        }
        if (photosTaken == photosToCompleteChallange)
        {
            timer.text = "Memory is full";
        }
    }

    public void UpdatePhotoTaken()
    {
        counter.text = photosTaken + "/7";
        if (photosTaken.Equals(photosToCompleteChallange))
            counter.text = "7/7 RUN!";
    }

    public int GetCounter()
    {
        return photosTaken;
    }

    public float GetCameraReloadTime()
    {
        return cameraReloadTime;
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
        if (photosTaken.Equals(photosToCompleteChallange))
            return;
        if (cameraReloadTime<0)
        {
            cameraReloadTime = 7f;
            photosTaken++;
            if (photosTaken.Equals(photosToCompleteChallange+))
                Debug.Log("Just survive and you will be a winner");
            Debug.Log("Photo taken");
            UpdatePhotoTaken();
        }   
        else
            Debug.Log("Camera is not ready yet");
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

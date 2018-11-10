using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeCamera : MonoBehaviour {

    int remainingSpace = 5;
    bool isActive = true;
    [SerializeField] GameObject negativeEffect;

    public void SetCameraSpace(int value)
    {
        remainingSpace = value;
    }

    public void ActivateCamera()
    {
        isActive = true;
        this.gameObject.SetActive(true);
        ActivateNegativeEffect();
    }

    void ActivateNegativeEffect()
    {
        negativeEffect.gameObject.SetActive(true);
    }

    public void DeactiveCamera()
    {
        isActive = false;
        this.gameObject.SetActive(false);
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
            remainingSpace -= 1;
        else
            Debug.Log("Not enough space on camera!");
    }

}

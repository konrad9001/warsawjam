using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NegativeCamera : Weapon {

    public INegativeCamera listener;
    int photosTaken = 0;
    int photosToCompleteChallange = 7;
    float cameraReloadTime = 7f;
    bool isActive = true;
    float timeOfTheGame = 0f;
    public Light light;
    public struct GameChallanges
    {
        public bool mutantPhotoTaken;
        public bool slowEnemyPhotoTaken;
        public bool fastEnemyPhotoTaken;
        public bool shaeFound;
        public bool remyFound;
        public bool reginaFound;
        public bool malcolmFound;
        public int enemyKillCounter;
        public int photographyOfTheVictimsCounter;
        public float timeOfTheGame;
    };

    public GameChallanges challenges = new GameChallanges();
    private void Start()
    {
        challenges.mutantPhotoTaken = false;
        challenges.slowEnemyPhotoTaken = false;
        challenges.fastEnemyPhotoTaken = false;
        challenges.shaeFound = false;
        challenges.remyFound = false;
        challenges.reginaFound = false;
        challenges.malcolmFound = false;
        challenges.enemyKillCounter = 0;
        challenges.photographyOfTheVictimsCounter = 0;
        challenges.timeOfTheGame = 0f;
    }


    [SerializeField] GameObject negativeEffect;
    [SerializeField] GameObject cameraUI;
    [SerializeField] Text counter;
    [SerializeField] Text timer;
    [SerializeField] Animator cameraUIAnim;

    public void ActivateCamera()
    {
        isActive = true;
        cameraUI.SetActive(true);
        ActivateNegativeEffect();
    }

    public override void UpdateTimer()
    {
        challenges.timeOfTheGame += Time.deltaTime;
        if(cameraUIAnim.GetBool(Keys.WeaponsAnimations.ON))
            StartCoroutine(wait());
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

    public void UpdateNumberOfDeathOponent()
    {
        challenges.enemyKillCounter = listener.GetNumberOfDeathOponent();
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
            CheckIfMutantIsOnFoto();
            CheckIfFastEnemyIsOnThePhoto();
            CheckIfNormalEnemyIsOnThePhoto();
            CheckIfReginaOnThePhoto();
            CheckIfShaeOnThePhoto();
            CheckIfMalcolmOnThePhoto();
            CheckIfRemyOnThePhoto();
            cameraUIAnim.SetBool(Keys.WeaponsAnimations.ON, true);
            Debug.Log("Photo taken");
            UpdatePhotoTaken();

            if (challenges.shaeFound && challenges.remyFound && challenges.reginaFound && challenges.malcolmFound)
                light.gameObject.SetActive(true);
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

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        cameraUIAnim.SetBool(Keys.WeaponsAnimations.ON, false);
    }

    public void CheckIfMutantIsOnFoto()
    {
        if (listener.CheckMutant())
            challenges.mutantPhotoTaken = true;
    }

    public void CheckIfNormalEnemyIsOnThePhoto()
    {
        if(listener.CheckNormal())
            challenges.slowEnemyPhotoTaken = true;
    }

    public void CheckIfFastEnemyIsOnThePhoto()
    {
        if (listener.CheckFast())
            challenges.fastEnemyPhotoTaken = true;
    }

    public void CheckIfShaeOnThePhoto()
    {
        if (listener.CheckShae())
        {
            challenges.shaeFound = true;
        }
            
    }

    public void CheckIfRemyOnThePhoto()
    {
        if (listener.CheckRemy())
        {
            challenges.remyFound = true;
            
        }
            
    }

    public void CheckIfReginaOnThePhoto()
    {
        if (listener.CheckRegina())
        {
            challenges.reginaFound = true;
            
        }
    }

    public void CheckIfMalcolmOnThePhoto()
    {
        if (listener.CheckMalcolm())
        {
            challenges.malcolmFound = true;
            
        }
    }

    public GameChallanges GetChallenges()
    {
        return challenges;
    }

}

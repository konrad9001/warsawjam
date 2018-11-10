

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{

    [SerializeField] Camera rifle;
    [SerializeField] ParticleSystem shootParticle;
    [SerializeField] Transform shootPos;
    [SerializeField] Animator shotgunAnimator;
    [SerializeField] bool isReloaded = true;

    bool isActive = true;

    public void ActivateShotgun()
    {
        isActive = true;
        this.gameObject.SetActive(true);
    }

    public void DeactivateShotgun()
    {
        isActive = false;
        this.gameObject.SetActive(false);
    }

    public bool IsShotgunActive()
    {
        return isActive;
    }

    public override string NameOfTheWeapon()
    {
        return Keys.Weapons.SHOTGUN;
    }

    public override void Shoot()
    {
        isReloaded = false;
        Debug.Log("ShootingFromShotgun");
        shootParticle.transform.position = shootPos.position;
        shootParticle.Play();
        Debug.DrawRay(rifle.transform.position, rifle.transform.forward, Color.green);
        RaycastHit hitOut;
        if (Physics.Raycast(rifle.transform.position, rifle.transform.forward, out hitOut, 40f, 1024))
        {
            hitOut.collider.gameObject.GetComponent<BaseEnemy>().Hit();
            Debug.Log("Damage!");
        }
    }

    public override void Reload()
    {
        if(!isReloaded)
            StartCoroutine(ReloadWeapon());
    }

    public IEnumerator ReloadWeapon()
    {
        shotgunAnimator.SetBool(Keys.WeaponsAnimations.RELOAD, true);
        yield return new WaitForSeconds(0.5f);
        shotgunAnimator.SetBool(Keys.WeaponsAnimations.RELOAD, false);
        isReloaded = true;
    }
}

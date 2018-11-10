﻿

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon {

    [SerializeField] Camera rifle;
    [SerializeField] ParticleSystem shootParticle;
    [SerializeField] Transform shootPos;

    bool isActive = true;

    public void ActivateShotgun()
    {
        isActive = true;
        //this.gameObject.SetActive(true);
    }

    public void DeactivateShotgun()
    {
        isActive = false;
        //this.gameObject.SetActive(false);
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
        Debug.Log("ShootingFromShotgun");
        shootParticle.transform.position = shootPos.position;
        shootParticle.Play();
        Debug.DrawRay(rifle.transform.position, Vector3.forward, Color.green);
        RaycastHit hitOut;
        if (Physics.Raycast(rifle.transform.position, Vector3.forward, out hitOut,40f,1024))
        {
            hitOut.collider.gameObject.GetComponent<BaseEnemy>().Hit();
            Debug.Log("Damage!");
        }
    }
}

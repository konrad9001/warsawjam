using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon {

    [SerializeField] Camera rifle;

    int dmg = 1;
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

    public int DealDamage()
    {
        return dmg;
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
        Debug.DrawRay(rifle.transform.position, Vector3.forward, Color.green);
        if (Physics.Raycast(rifle.transform.position, Vector3.forward,40f, 1024))
        { 
            Debug.Log("Damage taken: " + DealDamage());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    Weapon currentWeapon;

    public void SetCurrentWeapon(Weapon newWeapon)
    {
        currentWeapon = newWeapon;
    }

    public void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
            currentWeapon.Shoot();
    }

}

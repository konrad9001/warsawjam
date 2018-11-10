using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    Weapon currentWeapon;
    float timeBetweeenShoots = -1f;

    public void SetCurrentWeapon(Weapon newWeapon)
    {
        currentWeapon = newWeapon;
    }

    public void Shoot()
    {
        if (timeBetweeenShoots < 0)
            if (Input.GetMouseButtonDown(0))
            {
                currentWeapon.Shoot();
                timeBetweeenShoots = 1f;
            }
                
    }

    public void UpdateTime()
    {
        timeBetweeenShoots -= Time.deltaTime;
    }

}

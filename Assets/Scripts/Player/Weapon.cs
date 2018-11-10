using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public virtual string NameOfTheWeapon()
    {
        return "ERROR";
    }

    public virtual void Shoot()
    {
    }

    public virtual void Reload()
    { }
}

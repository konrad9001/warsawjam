using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour {

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

    public int DeadDamage()
    {
        return dmg;
    }

    public bool IsShotgunActive()
    {
        return isActive;
    }
}

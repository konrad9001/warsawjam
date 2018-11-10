using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerWeapon playerWeapon;
    [SerializeField] PlayerShooting playerShooting;
    public IPlayer listener;

    public void GetPlayerInput()
    {
        MovePlayerLook();
        CheckIfPlayerChangingWeapon();
        CheckIfPlayerShooting();
    }

    public string GetWieldedWeapon()
    {
        return playerWeapon.GetWieldedWeapon();
    }

    void MovePlayerLook()
    {
        playerMovement.Move();
    }

    void CheckIfPlayerChangingWeapon()
    {
        playerWeapon.ChangeWeapon();
        if (playerWeapon.IsShotgunActive())
            playerShooting.SetCurrentWeapon(playerWeapon.GetShotgun());
        else
            playerShooting.SetCurrentWeapon(playerWeapon.GetCamera());
    }

    void CheckIfPlayerShooting()
    {
        playerShooting.Shoot();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player hitted" + collision.collider.name);
    }
}

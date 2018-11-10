using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerWeapon playerWeapon;
    public IPlayer listener;

    public void GetPlayerInput()
    {
        MovePlayerLook();
        CheckIfPlayerChangingWeapon();
    }

    void MovePlayerLook()
    {
        playerMovement.Move();
    }

    void CheckIfPlayerChangingWeapon()
    {
        playerWeapon.ChangeWeapon();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player hitted" + collision.collider.name);
    }
}

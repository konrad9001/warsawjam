using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    public IPlayer listener;

    public void GetInputMovement()
    {
        MovePlayerLook();
    }

    void MovePlayerLook()
    {
        playerMovement.Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player hitted" + collision.collider.name);
    }
}

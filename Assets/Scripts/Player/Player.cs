using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerWeapon playerWeapon;
    [SerializeField] PlayerShooting playerShooting;
    [SerializeField] Rigidbody rb;
    [SerializeField] AudioSource clip;
    public IPlayer listener;
    float speed = 5f;

    public void GetPlayerInput()
    {
        MovePlayerLook();
        CheckIfPlayerChangingWeapon();
        CheckIfPlayerShooting();

        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");
        if (xMov != 0 || yMov != 0)
        {
            if(!clip.isPlaying)
                clip.Play();
        }
        else
            clip.Stop();

        Vector3 temp = (transform.forward * yMov + transform.right * xMov) * speed * Time.deltaTime;

        rb.MovePosition(transform.position + temp);
    }

    public string GetWieldedWeapon()
    {
        return playerWeapon.GetWieldedWeapon();
    }

    public PlayerShooting GetPlayerShooting()
    {
        return playerShooting;
    }

    public Weapon GetShotgun()
    {
        return playerWeapon.GetShotgun();
    }

    public Weapon GetNegativeCamera()
    {
        return playerWeapon.GetCamera();
    }

    void MovePlayerLook()
    {
        playerMovement.Move();
    }

    void CheckIfPlayerChangingWeapon()
    {
        if (playerWeapon.changingWeapon)
            return;
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
        if (collision.collider.tag == "exit")
        {
            listener.WinOfTheGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.tag.Equals(Keys.Tags.CLAWS))
                listener.PlayerIsDead();
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(other.gameObject.transform.forward*50f, ForceMode.Impulse);
        }
    }
}

   

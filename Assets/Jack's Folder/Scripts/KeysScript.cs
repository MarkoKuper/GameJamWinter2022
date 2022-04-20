using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysScript : MonoBehaviour
{
    public int keysNeeded;
    PlayerScript PlayerSC;
    Animator AnimController;
    bool ItsOpen;
    private void Start()
    {
        AnimController = gameObject.GetComponent<Animator>();
        PlayerSC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (PlayerSC.KeysCollected >= keysNeeded && ItsOpen == false)
            {
                PlayerSC.KeysCollected -= keysNeeded;
                AnimController.SetBool("DoorIsOpen", true);
                ItsOpen = true;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysScript : MonoBehaviour
{
    public int keysNeeded;
    PlayerScript PlayerSC;
    private void Start()
    {
        PlayerSC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (PlayerSC.KeysCollected >= keysNeeded)
            {
                PlayerSC.KeysCollected -= keysNeeded;
                Destroy(this.gameObject);
            }
        }
    }

}

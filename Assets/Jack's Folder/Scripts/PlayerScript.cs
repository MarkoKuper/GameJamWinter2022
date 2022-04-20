using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
public class PlayerScript : MonoBehaviour
{
    public int KeysCollected;
    public Image[] KeySprites;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        KeyCollector();
    }



    void KeyCollector()
    {

        for (int i = 0; i < KeySprites.Length; i++)
        {
            if (i < KeysCollected)
            {
                KeySprites[i].enabled = true;
            }
            else
            {
                KeySprites[i].enabled = false;
            }
        }
    }

    void AddKey(int Quantinty)
    {
        KeysCollected += Quantinty;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Key")
        {
            AddKey(1);
        }
    }
}

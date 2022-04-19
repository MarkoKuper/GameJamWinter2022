using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysScript : MonoBehaviour
{
    private int KeysCollected;
    public  Image[] KeySprites;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lvl2Stars : MonoBehaviour
{
    public int Stars;
    public Image[] StarsSprites;
    // Start is called before the first frame update
    void Start()
    {
        Stars = PlayerPrefs.GetInt("StarsLvl2");
    }
    public void LevelChecker()
    {
        for (int i = 0; i < StarsSprites.Length; i++)
        {
            if (i < Stars)
            {
                StarsSprites[i].enabled = true;
            }
            else
            {
                StarsSprites[i].enabled = false;
            }
        }
    }

}

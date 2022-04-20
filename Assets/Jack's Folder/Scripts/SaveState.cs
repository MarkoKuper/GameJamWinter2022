using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveState : MonoBehaviour
{
    public int LevelsBeat;
    public Image[] Levels;
    public 

    // Start is called before the first frame update
    void Start()
    {
        LevelsBeat = PlayerPrefs.GetInt("LevelsBeat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelChecker()
    {
        for (int i = 0; i < Levels.Length; i++)
        {
            if (i < LevelsBeat)
            {
                Levels[i].enabled = true;
            }
            else
            {
                Levels[i].enabled = false;
            }
        }
    }
}

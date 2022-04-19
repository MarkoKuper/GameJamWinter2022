using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Code for the pause works
    /// </summary>
    public static bool Paused = false; //Make it check if the game is paused, starts as false.
    public GameObject PauseMenuUI; //The UI
    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.Escape))//If the player press esc button
            {
                if (Paused) //If its paused resume the game
                {
                    Resume();
                }
                else //If it's not then will pause it.
                {
                    Pause();
                }
            }
        
        
        
    }
    public void Resume() //Make the game runs again
    {
        PauseMenuUI.SetActive(false); //Turn out the UI
        Time.timeScale = 1f; //Set the time scale back to 1
        Paused = false; //Turn paused into false
    }
    void Pause() //Make the game paused
    {
        PauseMenuUI.SetActive(true);// Turn paused into true
        Time.timeScale = 0f; //Set time scale to 0 to stop the game
        Paused = true; //Make the paused into true
    }
}

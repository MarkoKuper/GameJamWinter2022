using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridManager : MonoBehaviour
{ /// <summary>
  /// This code generate tiles for you to test it :)
  /// </summary>
    [SerializeField]
    private int rows = 5; //The rows of it (X)
    [SerializeField]
    private int cols = 8; //The collums of it (Y)
    [SerializeField]
    private float tileSize = 1; //How much they gonna be closer to each other (his size got bigger)
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid(); //Generate the grid on the start
    }

    private void GenerateGrid()
    {
        transform.position = new Vector2(0, 0); //Turn the vector into 0 so it focus on the middle
        GameObject refenceTile = (GameObject)Instantiate(Resources.Load("Metal Floor")); //See the tile you wanna test, change the "" to the name of what you wanna test. Needs to be on resources.
        for (int row = 0; row < rows; row++) //For each row < add one row (Based on the row you gonna add on the rows int)
        {
            for (int col = 0; col < cols; col++)//For each coll < add one row (Based on the row you gonna add on the colls int)
            {
                GameObject tile = (GameObject)Instantiate(refenceTile, transform); //Instatiante the tiles
                float posX = col * tileSize; // Put the pos x (Col based on your number) * the size you choosed
                float posY = row * -tileSize;// Put the pos y (Row based on your number) * the size you choosed

                tile.transform.position = new Vector2(posX, posY); //Put it on the position
            }
        }

        Destroy(refenceTile); //Destroy the reference tile you used
        float gridW = cols * tileSize; // The grid w is the number of cols * tile size
        float gridH = rows * tileSize; //Grid h is the number of the rows * tile size
        transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2); //Dunno why but without this code the grid will go off screen but when  i do it it go back to place.
    }
}

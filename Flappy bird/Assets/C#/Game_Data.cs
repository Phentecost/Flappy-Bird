using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game_Data
{
    public static int _birdColor {  get; private set; }
    public static int _backGround {  get; private set; }
    public static int _bestScore { get; private set; }

   public static void Randomize_Scene() 
   {
        _birdColor = Random.Range(0, 3);
        _backGround = Random.Range(0, 2);
   }

    public static void Update_Score() 
    {
        _bestScore++;
    }
}

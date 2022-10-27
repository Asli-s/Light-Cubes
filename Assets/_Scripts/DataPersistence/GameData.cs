using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class GameData 
{

    public int level;
    public Vector3 playerPosition;

    public bool music;
    public bool sound ;

    public bool won;

    public bool endlessLevel;
    public int highScore;

    public bool firstGame;
    //

    public GameData(){

        this.level =1;
        this.playerPosition = new Vector3(0,-3.5f, 0);

       this.music = true;
       this.sound = true;

       this.endlessLevel = false;

        this.highScore = 0;

        this.won = false;
        this.firstGame = true;
        }




}

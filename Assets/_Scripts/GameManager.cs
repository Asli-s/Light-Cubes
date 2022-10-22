using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IDataPersistence
{

    public static GameManager Instance;

    /*[HideInInspector]*/
    public int score = 0;
    public int level = 1;
    public Vector3 playerPosition;

    public bool music;
    public bool sound;
    public bool endlessLevel =false;

    public int highScore;

    public bool won;
    public bool alertOpen = false;

    public Button endlessButton;



    public Image endlessRect;

    public Material endlessActive;


    private Scene currentScene;

    public Material endlessNotActive;


    public bool firstGame;


    // Start is called before the first frame update
    void Start()
    {


        currentScene = SceneManager.GetActiveScene();
      score = 0;

        if (Instance == null)
        {
            Instance = this;
        }
      


        if(won == true && currentScene.name == "HomeScene")
        {
            endlessButton.interactable = true;

            endlessRect.material = endlessActive;
            endlessRect.color = new Color32(0, 255, 105, 255);

        
        }
        else if(won == false && currentScene.name == "HomeScene")
        {
            endlessRect.material = endlessNotActive;

            endlessButton.interactable = false;
            endlessRect.color = new Color32(101, 119, 127, 255);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }





    public void LoadData(GameData gameData)
    {
        this.music = gameData.music;
        this.sound = gameData.sound;


        this.won = gameData.won;

        this.endlessLevel = gameData.endlessLevel;
        this.level = gameData.level;
      
        this.playerPosition = gameData.playerPosition;
        this.highScore = gameData.highScore;


        this.firstGame = gameData.firstGame;
  
    }
    public void SaveData(GameData gameData)
    {
        gameData.music = this.music;
        gameData.sound = this.sound;


        gameData.highScore = this.highScore;
         gameData.endlessLevel = this.endlessLevel;
        

        gameData.won = this.won;

        gameData.level = this.level;
        gameData.playerPosition = this.playerPosition;



        gameData.firstGame = this.firstGame;

    }


}

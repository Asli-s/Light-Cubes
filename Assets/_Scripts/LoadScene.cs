using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
    
    
    {
    public void LoadArcadeScene()
    {

        GameManager.Instance.endlessLevel = false;
        GameManager.Instance.alertOpen = false;
        DataPersistenceManager.Instance.SaveGame();
        SceneManager.LoadScene("Arcade");
    }
    public void LoadEndlessScene()
    {
        GameManager.Instance.alertOpen = false;
        SceneManager.LoadScene("Endless");
        DataPersistenceManager.Instance.SaveGame();
        GameManager.Instance.endlessLevel = true;



    }


    public void LoadHomeScreenScene()
    {
        GameManager.Instance.alertOpen = false;
        GameManager.Instance.endlessLevel = false;
        DataPersistenceManager.Instance.SaveGame();

        SceneManager.LoadScene("HomeScene");

    }
}

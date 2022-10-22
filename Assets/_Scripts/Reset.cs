using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Reset : MonoBehaviour
{
    // Start is called before the first frame update

    //  public GameManager gameManager;
    public GameObject player;
    public GameObject camera;
    public TMPro.TextMeshProUGUI ScoreText;


    public void ResetToStart()
    {
        GameManager.Instance.won = false;
        GameManager.Instance.playerPosition = new Vector3(0, -3.5f, 0);
        GameManager.Instance.level =1;
        GameManager.Instance.firstGame = true;
        player.transform.position = new Vector3(0, -3.5f, 0);
        camera.transform.position = new Vector3(0, 0, -10);
        ScoreText.text = 0.ToString();
      /*  SceneManager.LoadScene(;*/
        
    }
}
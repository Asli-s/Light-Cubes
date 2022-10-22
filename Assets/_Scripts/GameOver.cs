using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public TMPro.TextMeshProUGUI highScoreTxt;
    public TMPro.TextMeshProUGUI timerSecondsText;
    private int timerSeconds = 5;
    private float timerFloat = 0;

    int timeValue=5;

    public GameObject restartButton;
    public GameObject mainBlock;

    public Image TimerCircle;
    public GameObject Panel;
    public Reset Reset;

    IEnumerator Timer;

  public  bool clicked =false;

    public Health health;


    public AdManager adManager;

    private void Start()
    {
     
        mainBlock.GetComponent<RectTransform>().localScale = new Vector3(0,0,1);
    }


    private void OnEnable()


    {

        timerFloat = timerSeconds;
        timeValue = timerSeconds;
        TimerCircle.GetComponent<Image>().fillAmount = 0;
        LeanTween.scale(mainBlock, new Vector3(1, 1, 1), 1).setEaseInOutElastic();
        highScoreTxt.text = GameManager.Instance?.score.ToString();
        Timer = TimerCountDown();
        StartCoroutine(Timer);
        GameManager.Instance.alertOpen = true;

    }



    IEnumerator TimerCountDown()
    {
      

        while (timerFloat > 0)
        {
            timerFloat -= Time.deltaTime;

            TimerCircle.GetComponent<Image>().fillAmount = timerFloat / timeValue;



            if (timerSeconds > (int)timerFloat)
            {

                timerSecondsText.text = timerSeconds.ToString();
                timerSeconds--;



            }
            yield return null;
        }

        timerSecondsText.text = timerSeconds.ToString();

        restartButton.SetActive(true);

        //activate restart;
        StopCountDown();
    }

    public void StopCountDown()
    {
        StopCoroutine(TimerCountDown());

    }



    public void RestatrtGame()
    {

        LeanTween.scale(mainBlock, new Vector3(0, 0, 1), 1).setEaseInOutElastic().setOnComplete(DeactivateGameObject);
        restartButton.SetActive(false);
        timerSeconds = 5;
   
    }


    private void DeactivateGameObject()
    {

        gameObject.SetActive(false);
        GameManager.Instance.alertOpen = false;
        GameManager.Instance.score = 0;

        SceneManager.LoadScene("Endless");
     
    }

    public void WatchAd()
    {
        if(clicked == false)
        {


        clicked = true;
            adManager.ckilcKButton();

        }
        print("click");
       



    }

    public void CloseGameOverALert()
    {
        clicked = false;
        LeanTween.scale(mainBlock, new Vector3(0, 0, 1), 1).setEaseInOutElastic().setOnComplete(CloseAlert);

    }


    public void CloseAlert()
    {
        restartButton.SetActive(false);
        timerSeconds = 5;
        gameObject.SetActive(false);
        GameManager.Instance.alertOpen = false;
        clicked = false;
    }



}

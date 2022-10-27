using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Health : MonoBehaviour
{

  public  GameObject[] HealthItems;
    public Sprite emptyBar;
    public Sprite fullBar;

    private int maxHealthPoint = 4;
    public int currentHealth = 4;

    private void Start()
    {
        maxHealthPoint = 4;
        currentHealth = maxHealthPoint;
        foreach(GameObject bar in HealthItems)
        {
            bar.GetComponent<Image>().sprite = fullBar;
        }
    }


    public void LoseLife()
    {
        if (currentHealth != 0)
        {

        currentHealth--;
        }
        if (currentHealth == 3)
        {
            HealthItems[3].GetComponent<Image>().sprite = emptyBar;
        }
        else if(currentHealth == 2)
        {
            HealthItems[2].GetComponent<Image>().sprite = emptyBar;
        }
        else if (currentHealth == 1)
        {
            HealthItems[1].GetComponent<Image>().sprite = emptyBar;
        }
        else
        {
            HealthItems[0].GetComponent<Image>().sprite = emptyBar;


        }
    }


    public void AddLife()
    {
        if(currentHealth < 4)
        {

        currentHealth++;
        }
        if (currentHealth == 4)
        {
            HealthItems[3].GetComponent<Image>().sprite = fullBar;
        }
        else if (currentHealth == 3)
        {
            HealthItems[2].GetComponent<Image>().sprite = fullBar;
        }
        else if (currentHealth == 2)
        {
            HealthItems[1].GetComponent<Image>().sprite = fullBar;
        }
        else
        {
            HealthItems[0].GetComponent<Image>().sprite = fullBar;


        }



    }


}

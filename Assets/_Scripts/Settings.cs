using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject SettingsAlert;

    public Sprite OnYes;
    public Sprite OffYes;
    public Sprite OnNo;
    public Sprite OffNo;

    public Button MusicButtonOn;
    public Button MusicButtonOff;
    public Button SoundButtonOn;
    public Button SoundButtonOff;





    public void ActivateSettingsAlert()
    {
     
        SettingsAlert.SetActive(true);
        if(GameManager.Instance.sound == true)
        {
            SoundButtonOff.image.sprite = OffNo;
            SoundButtonOn.image.sprite = OnYes;
        }
        else
        {
            SoundButtonOff.image.sprite = OffYes;
            SoundButtonOn.image.sprite = OnNo;

        }
        if(GameManager.Instance.music == true)
        {
            MusicButtonOff.image.sprite = OffNo;
            MusicButtonOn.image.sprite = OnYes;
        }
        else
        {
            MusicButtonOff.image.sprite = OffYes;
            MusicButtonOn.image.sprite = OnNo;

        }


    }

    public void MusicToggle()
    {
        if (GameManager.Instance.music == true
            )
        {
            GameManager.Instance.music = false; 
            MusicButtonOff.image.sprite = OffYes;
            MusicButtonOn.image.sprite = OnNo;

            FindObjectOfType<ThemeSound>().StopThemeSong();
            DataPersistenceManager.Instance.SaveGame();
        }
        else
        {
            GameManager.Instance.music = true;
            MusicButtonOff.image.sprite = OffNo;
            MusicButtonOn.image.sprite = OnYes;

        
            FindObjectOfType<ThemeSound>().PlayThemeSong();
            DataPersistenceManager.Instance.SaveGame();


        }
    }
    public void SoundToggle()
    {
        if (GameManager.Instance.sound == true
           )
        {
            SoundButtonOff.image.sprite = OffYes;
            SoundButtonOn.image.sprite = OnNo;

            GameManager.Instance.sound = false;
            DataPersistenceManager.Instance.SaveGame();

         
        }
        else
        {
            SoundButtonOff.image.sprite = OffNo;
            SoundButtonOn.image.sprite = OnYes;
            GameManager.Instance.sound = true;
          
            DataPersistenceManager.Instance.SaveGame();


        
        }
    }


}

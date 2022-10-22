using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsAlert : MonoBehaviour
{
    public GameObject mainBlock;
    // Start is called before the first frame update
    void OnEnable()
    {
        LeanTween.scale(mainBlock, new Vector3(10,10,1), 1).setEaseInOutElastic();
        GameManager.Instance.alertOpen = true;
        
    }
    public void CloseAlert()
    {
        LeanTween.scale(mainBlock, new Vector3(0,0,1), 1).setEaseInOutElastic().setOnComplete(Deactivate);

    }
    void Deactivate()
    {
        gameObject.SetActive(false);
        GameManager.Instance.alertOpen = false;

    }

}

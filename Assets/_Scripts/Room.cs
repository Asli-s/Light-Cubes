using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject virtualCam;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && collision.isTrigger == false)
        {
            virtualCam.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && collision.isTrigger == false)
        {
            virtualCam.SetActive(false);

        }

    }
}

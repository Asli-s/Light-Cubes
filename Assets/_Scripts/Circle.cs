using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Circle : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotationSpeed = 1.5f;
    private Scene scene;
    // Update is called once per frame


    private int randomSpeed;


    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (GameManager.Instance?.endlessLevel==true|| scene.name =="Endless")
        {
            randomSpeed = Random.Range(20, 30);
            rotationSpeed = randomSpeed;
        }
    }

    void Update()
    {



  
        gameObject.transform.Rotate(new Vector3(0, 0, 5) * Time.deltaTime*rotationSpeed);




    }
}

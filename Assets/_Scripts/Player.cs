using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    bool moveUp = false;
    public GameObject TriggerPoint;

    public GameObject Camera;
    public int rotationSpeed;
    public float moveSpeed;

    private Vector3 collisionCoordinates;
    private bool cameraFollow = false;
    private bool cameraHasArrived = false;
    public int blinkCount = 2;
    [Range(0, 1)]
    public float blinkSpeed = .01f;

    public float cameraSpeed;
    public GameObject collisionParticles;

    public TMPro.TextMeshProUGUI scoreText;

    private GameObject lastBarrier;
    public GameObject particlesBarrier;

    public GameManager gameManager;
    public Material winMaterial;

    float speed;

    private Material ownMaterial;

    public float cameraLastFrame;
    public int winScore;
    bool won = false;
    bool wonImmeadiate = false;

    public Shader removeShader;
    bool moving = false;

    public GameObject[] Levels;
    public List<GameObject> SpawnedLevels = new List<GameObject>();

    private int randomNumber = 0;
    private int randomSecondNumber = 0;
    private float lastYPos = 0;

    private GameObject newLevel;
    GameObject deleteObject;

    public GameObject YouWonText;
    public GameObject WonAlert;

    public Health Health;

    bool checkSpeed = false;

    Scene currentScene;

    public GameObject GameOverAlert;


    public GameObject tapText;

    public float cameraPos = 2;
    public float distance = 5;
    public float startPiont = 1.7f;


    void Start()
    {
        won = false;
        wonImmeadiate = false;

        currentScene = SceneManager.GetActiveScene();
        print(currentScene.name);

        if (currentScene.name == "Arcade" )
        {

            //
            if(gameManager.won == true)
            {
                YouWonText.SetActive(true);
                gameManager.score = 0;

            }
            else
            {
                YouWonText.SetActive(false);

            }
            if(gameManager.firstGame == false)
            {
                tapText.SetActive(false);
            }
            cameraPos = 3;
            distance = 5.5f;
            gameObject.transform.position = gameManager.playerPosition;
     //   print(gameManager.playerPosition);
        Camera.transform.position = new Vector3(gameManager.playerPosition.x, gameObject.transform.position.y+cameraPos, -10);
        gameManager.score = gameManager.level - 1;

        scoreText.text = gameManager.score.ToString();

            foreach (GameObject level in Levels)  {
                level.SetActive(true);
              newLevel=  Instantiate(level, new Vector3(0, startPiont,0), Quaternion.identity);
                startPiont += distance;
                SpawnedLevels.Add(newLevel);
            } ;
            lastBarrier = SpawnedLevels[20].gameObject.transform.GetChild(0).gameObject;
          SpawnedLevels[20].gameObject.transform.GetChild(1).gameObject.SetActive(true);
          SpawnedLevels[20].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            // print(lastBarrier);
            print(Levels[20]);

        }


        if ( currentScene.name == "Endless")
        {
            cameraPos = 3;
            won = false;
            wonImmeadiate = false;
            gameObject.transform.position = new Vector3(0,-3.5f,1);
            Camera.transform.position = new Vector3(0, gameObject.transform.position.y + cameraPos, -10);
            gameManager.score = 0;

          scoreText.text = "0";

            if (GameManager.Instance != null)
            {
            GameManager.Instance.score = 0;

            }

          gameManager.endlessLevel = true;
            randomNumber = Random.Range(0, 20);
            newLevel = Instantiate(Levels[randomNumber], new Vector3(0, startPiont, 0), Quaternion.identity);
            SpawnedLevels.Add(newLevel);
            lastYPos = startPiont + distance;


            randomSecondNumber = Random.Range(0, 20);

            newLevel = Instantiate(Levels[randomSecondNumber], new Vector3(0, lastYPos, 0), Quaternion.identity);
            SpawnedLevels.Add(newLevel);

        }
  

    }

    public static bool IsPointerOverGameObject()
    {
        // Check mouse
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }

        // Check touches
        for (int i = 0; i < Input.touchCount; i++)
        {
            var touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    return true;
                }
            }
        }

        return false;
    }


    void Update()
    {

        if ((Input.GetKeyDown("space") ||  (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) )&& wonImmeadiate == false && GameManager.Instance?.alertOpen == false && currentScene.name != "HomeScene"  )

        {

            if (IsPointerOverGameObject() == false) { 

           if(currentScene.name =="Arcade" &&  GameManager.Instance.won == false) 
            {

                if(GameManager.Instance.firstGame == true)
                {
                    GameManager.Instance.firstGame = false;
                    tapText.SetActive(false);
                }

            moveUp = true;
            moving = true;
            }
           else if(currentScene.name == "Endless"){
                moveUp = true;
                moving = true;
            }
            }
            //  }
        }
        if (cameraFollow == true && cameraHasArrived == false && wonImmeadiate == false)
        {
            if (Camera.transform.position.y < collisionCoordinates.y + cameraPos)
            {

                Camera.transform.position += new Vector3(0, cameraSpeed, 0);

            }
            else if (Camera.transform.position.y >= collisionCoordinates.y + cameraPos)
            {
                cameraFollow = false;
                cameraHasArrived = true;
                Camera.transform.position = new Vector3(0, collisionCoordinates.y + cameraPos, -10);


            }
        }
        if (cameraFollow == true && cameraHasArrived == false && won == true)
        {
            if (Camera.transform.position.y < collisionCoordinates.y +1.85f)
            {

                Camera.transform.position += new Vector3(0, cameraSpeed * 1.2f, 0);

            }
            else if (Camera.transform.position.y >= collisionCoordinates.y + 1.85f)
            {
                cameraFollow = false;
                cameraHasArrived = true;
                Camera.transform.position = new Vector3(0, collisionCoordinates.y +1.85f, -10);


            }
        }
    }
    private void FixedUpdate()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, 5) * Time.deltaTime * rotationSpeed);

        if (moveUp == true)
        {
          
            gameObject.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed;
            gameObject.transform.Rotate(new Vector3(0, 0, 5) * Time.deltaTime * 2);



            randomNumber = Random.Range(0, 20);

        }
      
    }

    private void moveCamera()
    {
        cameraFollow = true;
        cameraHasArrived = false;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveUp = false;
        print(collision.gameObject.name);
        

        if (collision.gameObject.tag != "Point" && collision.gameObject.tag != "Bounce") // died reset position to start 
        {
            FindObjectOfType<AudioManager>().Play("crash");

            Instantiate(collisionParticles, gameObject.transform.position, Quaternion.identity);
            Invoke("ShowPlayerRestart", 0.1f);
            gameObject.SetActive(false);


            moving = false;

            if ( currentScene.name == "Endless")
            {

                // after 5 lifes
                // show alert
                Health.LoseLife();
                if(Health.currentHealth == 0)
                {
                    GameOverAlert.SetActive(true);

                }

            }


        }
       
        if (collision.gameObject.tag == "Point")  //collision with goal point
        {



            collisionCoordinates = collision.gameObject.transform.position;
            gameObject.transform.position = collisionCoordinates;
            TriggerPoint.transform.position = collisionCoordinates; // new Triggrepoint to restart 

            Destroy(collision.gameObject);



            if ( currentScene.name == "Arcade")
            {

             
            GameManager.Instance.playerPosition = collisionCoordinates;
                if (winScore == GameManager.Instance.score+1)
                {

                    Instantiate(particlesBarrier, lastBarrier.transform.position, Quaternion.identity);
        
                    SpawnedLevels[20].gameObject.SetActive(false);
         
                    Invoke("SetWon", .8f);
                    FindObjectOfType<AudioManager>().Play("crack");
                    FindObjectOfType<AudioExtra>().Play("win");

                    wonImmeadiate = true;
                }
            }

            if (won)
            {
                LeanTween.scale(gameObject, new Vector3(0.8f, 0.8f, 1), 0.8f).setEaseInOutElastic().setDelay(.3f).setOnComplete(changeLooks);

                FindObjectOfType<AudioManager>().Play("success");
                GameManager.Instance.won = true;
                WonAlert.SetActive(true);



            }
            else if (won == false && moving == true)
            {
                moveCamera();
                moving = false;

                AddScore();
                if ( currentScene.name == "Endless")
                {
                    





                    lastYPos += distance;
                    newLevel = Instantiate(Levels[randomNumber], new Vector3(0, lastYPos, 0), Quaternion.identity);

                    if ((GameManager.Instance.score +2) %10==0 )
                    {
                        

                        var renderer = newLevel.GetComponentsInChildren<SpriteRenderer>().FirstOrDefault(r => r.tag == "Point");
                        print(renderer);
                     renderer.material = winMaterial;

                   renderer.color = new Color32(255, 76, 0, 255);


                    }

                    if (GameManager.Instance.score % 10 == 0){
                        FindObjectOfType<AudioManager>().Play("success");
                        Health.AddLife();


                    }
                    else
                    {
                        FindObjectOfType<AudioManager>().Play("goalpoint");

                    }




                    SpawnedLevels.Add(newLevel);
                 

                    // no more than active 3 Levels
                    checkSpeed = false;
                    if (SpawnedLevels.Count > 3)
                    {
                        deleteObject = SpawnedLevels.First();
                        Destroy(deleteObject);

                    }
                    //Level speed differentiate 

                    if (SpawnedLevels[1].GetComponentInChildren<Circle>() != null && SpawnedLevels[2].GetComponentInChildren<Circle>() != null)
                    {
                        print("both circle script");

                        if (SpawnedLevels[1].GetComponentInChildren<Circle>().rotationSpeed == SpawnedLevels[2].GetComponentInChildren<Circle>().rotationSpeed)
                        {
                            print("SAMMEEE SPEEED!");
                            SpawnedLevels[2].GetComponentInChildren<Circle>().rotationSpeed -= 4;
                        }
                    }

                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("goalpoint");

                }


            }

        }
    }
    private void changeLooks()
    {
        gameObject.GetComponent<SpriteRenderer>().material = winMaterial;

        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 76, 0, 255);


    }

    private void AddScore()
    {
      

        if (currentScene.name == "Arcade"
            )
        {
            GameManager.Instance.level += 1;
            GameManager.Instance.score = GameManager.Instance.level - 1;

            scoreText.text = GameManager.Instance.score.ToString();
           

        }
        if ( currentScene.name == "Endless")
        {
         
            if(gameManager.score == 0)
            {
                gameManager.score = 1;   
                    GameManager.Instance.score = 0;

               

            }

            GameManager.Instance.score += 1;

            scoreText.text = GameManager.Instance.score.ToString();
            SpawnedLevels.RemoveAll(s => s == null);
            print(SpawnedLevels);

        }


       
       
    }
    void SetWon()
    {
        won = true;
        moveUp = true;

    }


    private void ShowPlayerRestart()
    {
        gameObject.transform.position = TriggerPoint.transform.position;
        gameObject.SetActive(true);

        print(TriggerPoint.transform.position);
        StartCoroutine(PlayerBlink(blinkCount));
    }


    IEnumerator PlayerBlink(int blinkCount)
    {



        print(blinkCount);
        while (blinkCount > 0)
        {
  
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
            print(blinkCount);
            yield return new WaitForSeconds(blinkSpeed + 0.2f);
     
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(blinkSpeed);


            blinkCount--;
        }
    }


}

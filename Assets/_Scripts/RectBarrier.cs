using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectBarrier : MonoBehaviour
{
    // Start is called before the first frame update
    bool movingRight = false;
    bool movingLeft = false;

    public float speed ;
    bool endPoint = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movingLeft == false && endPoint == false && movingRight == false)
        {
            movingLeft = true;

        }
    
     
        if (movingLeft == true && endPoint == false)
        {
            if (gameObject.transform.position.x <= -1.8f)
            {
                endPoint = true;

            }
            else
            {

            gameObject.transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
            }
        }
   if (movingRight == true && endPoint == false)
            {
                if (gameObject.transform.position.x>= 1.8f)
                {
                    endPoint = true;
                
                }else
                gameObject.transform.position += new Vector3(1 *speed * Time.deltaTime, 0, 0);
            }

       if ( endPoint == true)
        {
            if(movingRight == true)
            {

    movingLeft = true;
                movingRight = false;
                endPoint = false;

            }

            else if( movingLeft == true)
            {

                movingLeft = false;
            movingRight = true;
            endPoint = false;
            }
       
   

    }
}
}

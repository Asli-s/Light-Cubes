using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleRect : MonoBehaviour
{

    bool movingRight_R = false;
    bool movingLeft_R = false; bool movingRight_L = false;
    bool movingLeft_L = false;

    public float speed;
    bool endPoint_R = false;
    bool endPoint_L = false;
    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "rectBarrierLeft")
        {
            if (movingLeft_L == false && endPoint_L == false && movingRight_L == false)
            {
                movingLeft_L = true;

            }


            if (movingLeft_L == true && endPoint_L == false)
            {
                if (gameObject.transform.position.x <= -2)
                {
                    endPoint_L = true;

                }
                else
                {

                    gameObject.transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
                }
            }
            if (movingRight_L == true && endPoint_L == false)
            {
                if (gameObject.transform.position.x >= -.5f)
                {
                    endPoint_L = true;

                }
                else
                    gameObject.transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);
            }

            if (endPoint_L == true)
            {
                if (movingRight_L == true)
                {

                    movingLeft_L = true;
                    movingRight_L = false;
                    endPoint_L = false;

                }

                else if (movingLeft_L == true)
                {

                    movingLeft_L = false;
                    movingRight_L = true;
                    endPoint_L = false;
                }



            }
        }
    
        else
        {
      if(movingLeft_R == false && endPoint_R == false && movingRight_R == false)
        {
            movingRight_R = true;

        }


if (movingLeft_R == true && endPoint_R == false)
{
    if (gameObject.transform.position.x <= 0.5f)
    {
                   
        endPoint_R = true;

    }
    else
    {

        gameObject.transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
    }
}
if (movingRight_R == true && endPoint_R == false)
{
    if (gameObject.transform.position.x >= 2)
    {
        endPoint_R = true;

    }
    else
        gameObject.transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);
}

if (endPoint_R == true)
{
    if (movingRight_R == true)
    {

        movingLeft_R = true;
        movingRight_R = false;
        endPoint_R = false;

    }

    else if (movingLeft_R == true)
    {

        movingLeft_R = false;
        movingRight_R = true;
        endPoint_R = false;
    }



}
}

        }
    }


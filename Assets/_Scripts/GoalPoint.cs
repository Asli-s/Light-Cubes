using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    bool scaleUp = false;
    public float animationSpeed ;


    void Start()
    {
        //
        ScaleDown();
    }
    private void Update()
    {
        
    }
    void changeScaleDirection()
    {
        if (scaleUp == false)
        {
            scaleUp = true;
            ScaleBig();
        }
        else
        {
            scaleUp = false;
            ScaleDown();
        }
    }

    void ScaleDown()
    {
        LeanTween.scale(gameObject, new Vector3(0.2f, 0.2f, 1), animationSpeed).setEaseInOutBounce().setOnComplete(changeScaleDirection);

    }
    void ScaleBig()
    {
        LeanTween.scale(gameObject, new Vector3(0.3f, 0.3f, 1),animationSpeed).setEaseInOutBounce().setOnComplete(changeScaleDirection);


    }
}

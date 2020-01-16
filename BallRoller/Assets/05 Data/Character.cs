using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private const float  MAX_SPEED = 40f;
    
    private int healthPoints;
    private int initHealthPoints;
    private float speed;

    public Character()
    {
        Debug.Log("New Character initiated");
       
        //Default character stats
        healthPoints = 100;
        speed = 0f;
        initHealthPoints = healthPoints;
    }

    public void SetHealth(int healthPts){
        
        healthPoints = initHealthPoints = healthPts;
    }

    public int GetHealth()
    {
        return healthPoints;
    }


    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speedPts)
    {       
         if(speedPts<=MAX_SPEED)
            speed += speedPts;
         else 
            speed = MAX_SPEED;

        Debug.Log("Current speed is " + speed.ToString());
    }


    public virtual void Start()
    {
        Debug.Log("Start() called");
    }

    public virtual void Update()
    {

    }

    public virtual void OnTriggerEnter() 
    {

    }

    public virtual void OnDisable()
    {
        Debug.Log("Game stops");
    }


    
    public virtual void DeductHealth()
    {
        if(healthPoints>1)
            healthPoints -= 1;
        else
            OnDisable();              
    }

    public virtual void AddHealth()
    {
        if(healthPoints<100)
            healthPoints += 1;
    }

    public void PrintHealth()
    {
        Debug.Log("Current health is "+healthPoints.ToString());
    }
}

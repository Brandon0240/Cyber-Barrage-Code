using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spritechange : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sprite;
    float timer = 4;
    bool cooldown;


    bool duration = false;
    float durationTimer = 2;
    bool change = false;
    bool defense = false; 


    void Start()
    {
        cooldown = false;
        
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1, 1, 1, 0);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R)&&cooldown == false)
        {
           
           
            cooldown = true;
            timer = 4;
            change = true;
            durationTimer = 2;
        }
        if(cooldown)
        {
            Timer();
        }
     
        
            changeTimer();
        

    }
    void Timer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            cooldown = false;
        }
     //   Debug.Log("Timer " + timer);
    }
    
    
    
    void changeTimer()
    {
        durationTimer -= Time.deltaTime;
      //   Debug.Log("durationTimer " + durationTimer);
        if (durationTimer <= 0)
        {
            sprite.color = new Color(1, 1, 1, 0);
            defense = false; 
        }
        else
        {
            sprite.color = new Color(1, 1, 1, 1);
            defense = true;
        }
    }
    public bool getDefense()
    {
        return defense;
    }
}

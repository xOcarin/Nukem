using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPointHandler : MonoBehaviour
{
    public double kpCounter = 0;
    public double bpCounter = 0;

    public bool pirateBool = false;
    public bool startSwarm = false;
    public bool swarmBool = false;
    
    [SerializeField] 
    public TextMeshProUGUI kpText; 
    public TextMeshProUGUI bpText;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //GOAL TOKENS
        if (collision.gameObject.tag == "Pendant")
        {
            kpCounter = kpCounter + 25;
        }
        if (collision.gameObject.tag == "CookBook")
        {
            kpCounter++;
        }
        if (collision.gameObject.tag == "BrowniePoint")
        {
            bpCounter++;
        }
        
        
        //Porfessors/PowerUps
        if (collision.gameObject.tag == "American")
        {
            bpCounter = 0;
            kpCounter = kpCounter * 2;
        }
        if (collision.gameObject.tag == "British")
        {
            
        }
        if (collision.gameObject.tag == "German")
        {
            
        }
        
        
        //ENIMIES
        if (collision.gameObject.tag == "Pointer")
        {
            if ((kpCounter / 2) > 10)
            {
                kpCounter = kpCounter / 2;
            }
            else
            {
                kpCounter = kpCounter - 10;
            }
        }
        if (collision.gameObject.tag == "Pirate")
        {
            Debug.Log(" EHERHEHREHREHHER::::::       " + pirateBool);
            StartCoroutine(SetPirateTimeOut());
        }
        if (collision.gameObject.tag == "Swarm")
        {
            
        }
    }
    
    
    //Pirate Freeze Timer Code
    private IEnumerator SetPirateTimeOut()
    {
        pirateBool = true;
        
        yield return new WaitForSeconds(10f);
        
        pirateBool = false; 
    }
    
    
    
    //Swarm Timer Code;
    private IEnumerator SetSwarmTimeOut()
    {
        for (int i = 0; i < 10; i++)
        {
            // Code to execute every 1 second.
            Debug.Log("Something happening every 1 second." + i);

            // Wait for 1 second.
            yield return new WaitForSeconds(1f);
        }
    }

    private void Start()
    {
        //REMEMBER THIS FOR SPAWNING
        //StartCoroutine(SetSwarmTimeOut()); THIS IS THE CALL TO START THE SWARM METHOD;
    }

    void Update()
    {
        kpText.text = kpCounter.ToString();
        bpText.text = bpCounter.ToString();
        
    }
}



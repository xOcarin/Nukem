using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class PlayerPointHandler : MonoBehaviour
{
    //Point Counters
    public double kpCounter = 0;    // knowledge point counter
    public double bpCounter = 0;    // brownie point counter
    
    //Power-Up Variables
    public bool britishImmunity = false;
    
    //Enemy Bools
    public bool pirateBool = false;
    public bool startSwarm = false;
    public bool swarmBool = false;
    
    
    //Text Stuff
    [SerializeField] 
    public TextMeshProUGUI kpText; 
    public TextMeshProUGUI bpText;
    
    //Obtaining Prefab Variables
    public TokenSpawnScript spawner;
    
    
    //animation stuff
    private Animator anim;

    private bool isHitByPirate;
    private bool fallFinished;
    
    private void Start()
    {
        //REMEMBER THIS FOR SPAWNING
        //StartCoroutine(SetSwarmTimeOut()); THIS IS THE CALL TO START THE SWARM METHOD;
        spawner = GetComponent<TokenSpawnScript>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        kpText.text = kpCounter.ToString();
        bpText.text = bpCounter.ToString();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //GOAL TOKEN COLLISION
        if (collision.gameObject.tag == "Pendant")
        {
            Destroy(collision.gameObject);
            kpCounter = kpCounter + 25;
        }
        if (collision.gameObject.tag == "CookBook")
        {
            Destroy(collision.gameObject);
            kpCounter++;
        }
        if (collision.gameObject.tag == "BrowniePoint")
        {
            Destroy(collision.gameObject);
            bpCounter++;
        }
        
        
        //PROFESSOR COLLISION
        // removed resetting bpCounter if player doesn't have enoyght points because I'm not sure if it's intended ~Evan
        if (collision.gameObject.tag == "AmericanPowerUp")
        {
            if (bpCounter >= 10)
            {
                Debug.Log("The American Algorithmic Amplifier");
                Destroy(collision.gameObject);
                kpCounter = kpCounter * 2;
                bpCounter = 0;
            }
            else
            {
                Destroy(collision.gameObject);
                //bpCounter = 0;
            }
        }
        if (collision.gameObject.tag == "BritishPowerUp")
        {
            if (bpCounter >= 10)
            {
                Debug.Log("The British Invasion");
                Destroy(collision.gameObject);
                StartCoroutine(SetImmuneTimeOut());
                bpCounter = 0;
            }
            else
            {
                Destroy(collision.gameObject);
                //bpCounter = 0;
            }
        }
        if (collision.gameObject.tag == "GermanPowerUp")
        {
            if (bpCounter >= 10)
            {
                Debug.Log("The Ole' Knowledge Bomb");
                Destroy(collision.gameObject);
                //OleKnowldgeBomb(): PLACEHOLDER
                bpCounter = 0;
            }
            else
            {
                Destroy(collision.gameObject);
                //bpCounter = 0;
            }
        }
        
        
        //ENIMIE COLLISION
        if (collision.gameObject.tag == "Pointer" && britishImmunity == false)
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
        if (collision.gameObject.tag == "Pirate" && britishImmunity == false)
        {
            Destroy(collision.gameObject);
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
        StartCoroutine(fallingAnim());
        anim.SetBool("fallFinished", true);
        yield return new WaitForSeconds(10f); //amount of time in seconds
        anim.SetBool("fallFinished", false);
        pirateBool = false; 
    }
    
    private IEnumerator fallingAnim()
    {
        anim.SetBool("isHitByPirate", true);
        yield return new WaitForSeconds(1f); //amount of time in seconds
        anim.SetBool("isHitByPirate", false);
        
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

    //British Power Timer
    private IEnumerator SetImmuneTimeOut()
    {
        britishImmunity = true;
        
        yield return new WaitForSeconds(10f);
        
        britishImmunity = false; 
    }
    
}



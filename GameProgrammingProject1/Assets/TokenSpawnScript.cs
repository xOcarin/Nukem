using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = Unity.Mathematics.Random;


[System.Serializable]
public class Token
{
    public float spawnTime;
    public GameObject gameObject1; // Assuming this is the prefab
    public GameObject gameObject2; // Assuming this is the name

    public Token(float time, GameObject prefab, GameObject name)
    {
        this.spawnTime = time;
        this.gameObject1 = prefab;
        this.gameObject2 = name;
    }
}


public class TokenSpawnScript : MonoBehaviour
{
    
    
    [SerializeField]
    // Prefabs
    public GameObject OleProfessorPrefab;
    public GameObject BritishProfessorPrefab;
    public GameObject AmericanProfessorPrefab;
    public GameObject cookbookPrefab;
    public GameObject pendantPrefab;
    public GameObject browniePrefab;
    public GameObject piratePrefab;
    public GameObject nullPrefab;
    public GameObject swarmPrefab;

    // GameObjects
    public GameObject OleProfessor;
    public GameObject BritishProfessor;
    public GameObject AmericanProfessor;
    public GameObject cookbook;
    public GameObject pendant;
    public GameObject brownie;
    public GameObject pirate;
    public GameObject nullP;
    public GameObject swarm;

    public PlayerPointHandler handler;
    
    
    
    //bools for handling spawning.
    public bool AmericanSpawning = false;
    public bool GermanSpawning = false;
    public bool BritshSpawning = false;
    public bool CookBookSpawning = false;
    public bool PendantSpawning = false;
    public bool BrowniePointSpawning = false;
    public bool PirateSpawning = false;
    public bool NullSpawning = false;
    public bool SwarmSpawning = false;
    
    //times
    public float shortTime = 3f;
    public float medTime = 5f;
    public float longTime = 7f;
    
    
    private Token[] EnemyArr; 
    private Token[] PowerUpArr; 
    private Token[] GoalArr; 
    
    
    
    
    
    
   

    // Start is called before the first frame update
    void Start()
    {
        EnemyArr = new Token[3];
        PowerUpArr = new Token[3];
        GoalArr = new Token[3];
        //token Objects
 
        PowerUpArr[0] = new Token(3.0f, OleProfessorPrefab, OleProfessor);
        PowerUpArr[1] = new Token(3.0f, BritishProfessorPrefab, BritishProfessor);
        PowerUpArr[2] = new Token(3.0f, AmericanProfessorPrefab, AmericanProfessor);
        
        GoalArr[0] = new Token(5.0f, cookbookPrefab, cookbook);
        GoalArr[1] = new Token(5.0f, pendantPrefab, pendant);
        GoalArr[2] = new Token(5.0f, browniePrefab, brownie);
        
        EnemyArr[0] = new Token(10.0f, piratePrefab, pirate);
        EnemyArr[1] = new Token(10.0f, nullPrefab, nullP);
        EnemyArr[2] = new Token(10.0f, swarmPrefab, swarm);

        StartCoroutine(SpawnCycleGoal(GoalArr));
        StartCoroutine(SpawnCycleEnemy(EnemyArr));
        StartCoroutine(SpawnCyclePowerUp(PowerUpArr));

    }
    
    
    IEnumerator SpawnCycleGoal(Token[] tokensToSpawn)
    {
        Token randomToken;
        while (true)
        {
            System.Random RandomNoForToken = new System.Random();
            int Choice = RandomNoForToken.Next(0, 100);
            if (Choice > 0 && Choice < 15)
            {
                randomToken = tokensToSpawn[2];
                StartCoroutine(SpawnSomething(randomToken.spawnTime, randomToken.gameObject1, randomToken.gameObject2));
                StartCoroutine(SpawnSomething(randomToken.spawnTime, randomToken.gameObject1, randomToken.gameObject2));
                StartCoroutine(SpawnSomething(randomToken.spawnTime, randomToken.gameObject1, randomToken.gameObject2));
            }
            else if (Choice > 15 && Choice < 35)
            {
                randomToken = tokensToSpawn[1];
                StartCoroutine(SpawnSomething(randomToken.spawnTime, randomToken.gameObject1, randomToken.gameObject2));
            }
            else if (Choice > 35 && Choice < 75)
            {
                randomToken = tokensToSpawn[0];
                StartCoroutine(SpawnSomething(randomToken.spawnTime, randomToken.gameObject1, randomToken.gameObject2));
            }
            Debug.Log(Choice);
            
            
            
            

               
        
                
            
            float time = 0f + UnityEngine.Random.value * 3f;
            //Debug.Log(time);
            // Wait for some time before starting the next set of coroutines
            yield return new WaitForSeconds(time);
        }
    }
    
    IEnumerator SpawnCycleEnemy(Token[] tokensToSpawn)
    {
        Token randomToken;
        while (true)
        {
            System.Random RandomNoForToken = new System.Random();
            int Choice = RandomNoForToken.Next(0, 100);
            if (Choice > 0 && Choice < 20)
            {
                randomToken = tokensToSpawn[2];
                StartCoroutine(SpawnSomething(randomToken.spawnTime, randomToken.gameObject1, randomToken.gameObject2));

            }
            else if (Choice > 20 && Choice < 40)
            {
                randomToken = tokensToSpawn[0];
                StartCoroutine(SpawnSomething(randomToken.spawnTime, randomToken.gameObject1, randomToken.gameObject2));
            }
            else if (Choice > 40 && Choice < 50)
            {
                randomToken = tokensToSpawn[1];
                StartCoroutine(SpawnPointer(randomToken.spawnTime, randomToken.gameObject1, randomToken.gameObject2));
            }
            Debug.Log(Choice);
            
            
            
            

               
        
                
            
            float time = 3f + UnityEngine.Random.value * 4f;
            //Debug.Log(time);
            // Wait for some time before starting the next set of coroutines
            yield return new WaitForSeconds(time);
        }
    }


    IEnumerator SpawnCyclePowerUp(Token[] tokensToSpawn)
    {
        Token randomToken;
        while (true)
        {
            System.Random RandomNoForToken = new System.Random();
            int Choice = RandomNoForToken.Next(0, 100);
            if (Choice > 0 && Choice < 10)
            {
                randomToken = tokensToSpawn[0];
                StartCoroutine(SpawnSomething(randomToken.spawnTime, randomToken.gameObject1, randomToken.gameObject2));

            }
            else if (Choice > 10 && Choice < 20)
            {
                randomToken = tokensToSpawn[1];
                StartCoroutine(SpawnSomething(randomToken.spawnTime, randomToken.gameObject1, randomToken.gameObject2));
            }
            else if (Choice > 20 && Choice < 25)
            {
                randomToken = tokensToSpawn[2];
                StartCoroutine(SpawnSomething(randomToken.spawnTime, randomToken.gameObject1, randomToken.gameObject2));
            }
            Debug.Log(Choice);
            
            
            
            

               
        
                
            
            float time = 3f + UnityEngine.Random.value * 4f;
            //Debug.Log(time);
            // Wait for some time before starting the next set of coroutines
            yield return new WaitForSeconds(time);
        }
    }
    
    
    
    //SPAWN
    IEnumerator SpawnSomething(float waitTime, GameObject prefab, GameObject name)
    {
        
            System.Random Randomx = new System.Random();
            int x = Randomx.Next(-9, 9);
            System.Random Randomy = new System.Random();
            int y = Randomy.Next(-5, 5);
            
            Vector3 position = new Vector3(x, y, -1f);
            name = Instantiate(prefab, position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            Destroy(name);   
        
    }
    
    IEnumerator SpawnPointer(float waitTime, GameObject prefab, GameObject name)
    {
        int x = (UnityEngine.Random.Range(0, 2) == 0) ? -8 : 8;
        System.Random Randomy = new System.Random();
        int y = Randomy.Next(-4, 4);
            
        Vector3 position = new Vector3(x, y, -1f);
        name = Instantiate(prefab, position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        Destroy(name);   
        
    }
    
}

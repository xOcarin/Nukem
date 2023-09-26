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
    
    
    private Token[] thingsToSpawnArr; 
    
    
    
   

    // Start is called before the first frame update
    void Start()
    {
        thingsToSpawnArr = new Token[9];
        //token Objects
        thingsToSpawnArr[0] = new Token(3.0f, OleProfessorPrefab, OleProfessor);
        thingsToSpawnArr[1] = new Token(3.0f, BritishProfessorPrefab, BritishProfessor);
        thingsToSpawnArr[2] = new Token(3.0f, AmericanProfessorPrefab, AmericanProfessor);
        thingsToSpawnArr[3] = new Token(5.0f, cookbookPrefab, cookbook);
        thingsToSpawnArr[4] = new Token(5.0f, pendantPrefab, pendant);
        thingsToSpawnArr[5] = new Token(5.0f, browniePrefab, brownie);
        thingsToSpawnArr[6] = new Token(10.0f, piratePrefab, pirate);
        thingsToSpawnArr[7] = new Token(10.0f, nullPrefab, nullP);
        thingsToSpawnArr[8] = new Token(10.0f, swarmPrefab, swarm);

        StartCoroutine(SpawnCycle(thingsToSpawnArr));


    }
    
    
    IEnumerator SpawnCycle(Token[] tokensToSpawn)
    {
        while (true)
        {
            List<int> uniqueIndices = new List<int>();
            System.Random randomIndex = new System.Random();

            // Generate three unique random indices
            while (uniqueIndices.Count < 3)
            {
                int randomTokenIndex = randomIndex.Next(0, tokensToSpawn.Length);
                if (!uniqueIndices.Contains(randomTokenIndex))
                {
                    uniqueIndices.Add(randomTokenIndex);
                }
            }

            // Start coroutines for the three unique indices
            foreach (int randomTokenIndex in uniqueIndices)
            {
                Token randomToken = tokensToSpawn[randomTokenIndex];
                if (randomTokenIndex == 5 || randomTokenIndex == 3) //looking for brownie or cookbook
                {
                    for (int i = 0; i < 3; i++)
                    {
                        StartCoroutine(SpawnSomething(randomToken.spawnTime, randomToken.gameObject1, randomToken.gameObject2));
                    }
                }
                else
                {
                    StartCoroutine(SpawnSomething(randomToken.spawnTime, randomToken.gameObject1, randomToken.gameObject2));
                }
                
            }

            // Wait for some time before starting the next set of coroutines
            yield return new WaitForSeconds(5f);
        }
    }



    
    
    
    //SPAWN
    IEnumerator SpawnSomething(float waitTime, GameObject prefab, GameObject name)
    {
        
            System.Random Randomx = new System.Random();
            int x = Randomx.Next(-9, 9);
            System.Random Randomy = new System.Random();
            int y = Randomy.Next(-4, 4);
            
            Vector3 position = new Vector3(x, y, -1f);
            name = Instantiate(prefab, position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            Destroy(name);   
        
    }
    
}

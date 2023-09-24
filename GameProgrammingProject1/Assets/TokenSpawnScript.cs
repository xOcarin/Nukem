using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = Unity.Mathematics.Random;

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

    // GameObjects
    public GameObject OleProfessor;
    public GameObject BritishProfessor;
    public GameObject AmericanProfessor;
    public GameObject cookbook;
    public GameObject pendant;
    public GameObject brownie;
    public GameObject pirate;
    
    public PlayerPointHandler handler;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // floats should match despawn time so multiple can't spawn at once
        // the professors can be different since they spawn so infrequently

        // can comment these out to prevent things from spawning
        StartCoroutine(SpawnOleProfessor(10.0f));       // rare
        StartCoroutine(SpawnBritishProfessor(10.0f));   // rare
        StartCoroutine(SpawnAmericanProfessor(20.0f));  // very rare
        StartCoroutine(SpawnCookBook(1.5f));            // very often
        StartCoroutine(SpawnPendant(3.0f));             // often
        StartCoroutine(SpawnBrowniePoint(5.0f));        // medium
        StartCoroutine(SpawnPirate(5.0f));              // medium
    }

    IEnumerator SpawnOleProfessor(float waitTime)
    {
        while (true)
        {
            System.Random Randomx = new System.Random();
            int x = Randomx.Next(-9, 9);
            System.Random Randomy = new System.Random();
            int y = Randomy.Next(-4, 4);

            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(x, y, -1f);
            OleProfessor = Instantiate(OleProfessorPrefab, position, Quaternion.identity);
            StartCoroutine(DespawnOleProfessor(OleProfessor, 5.0f));
        }
    }
    IEnumerator DespawnOleProfessor(GameObject OleProfessor, float despawnTime)
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(OleProfessor);  // Destroy the OleProfessor after despawnTime
    }

    IEnumerator SpawnBritishProfessor(float waitTime)
    {
        while (true)
        {
            System.Random Randomx = new System.Random();
            int x = Randomx.Next(-9, 9);
            System.Random Randomy = new System.Random();
            int y = Randomy.Next(-4, 4);

            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(x, y, -1f);
            BritishProfessor = Instantiate(BritishProfessorPrefab, position, Quaternion.identity);
            StartCoroutine(DespawnBritishProfessor(BritishProfessor, 5.0f));
        }
    }
    IEnumerator DespawnBritishProfessor(GameObject BritishProfessor, float despawnTime)
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(BritishProfessor);  // Destroy the BritishProfessor after despawnTime
    }

    IEnumerator SpawnAmericanProfessor(float waitTime)
    {
        while (true)
        {
            System.Random Randomx = new System.Random();
            int x = Randomx.Next(-9, 9);
            System.Random Randomy = new System.Random();
            int y = Randomy.Next(-4, 4);

            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(x, y, -1f);
            AmericanProfessor = Instantiate(AmericanProfessorPrefab, position, Quaternion.identity);
            StartCoroutine(DespawnAmericanProfessor(AmericanProfessor, 5.0f));
        }
    }
    IEnumerator DespawnAmericanProfessor(GameObject AmericanProfessor, float despawnTime)
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(AmericanProfessor);  // Destroy the AmericanProfessor after despawnTime
    }

    IEnumerator SpawnCookBook(float waitTime)
    {
        while (true)
        {
            System.Random Randomx = new System.Random();
            int x = Randomx.Next(-9, 9);
            System.Random Randomy = new System.Random();
            int y = Randomy.Next(-4, 4);

            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(x, y, -1f);
            cookbook = Instantiate(cookbookPrefab, position, Quaternion.identity);
            StartCoroutine(DespawnCookBook(cookbook, 1.5f));
        }
    }
    IEnumerator DespawnCookBook(GameObject cookbook, float despawnTime)
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(cookbook);  // Destroy the cookbook after despawnTime
    }

    IEnumerator SpawnPendant(float waitTime)
    {
        while (true)
        {
            System.Random Randomx = new System.Random();
            int x = Randomx.Next(-9, 9);
            System.Random Randomy = new System.Random();
            int y = Randomy.Next(-4, 4);

            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(x, y, -1f);
            pendant = Instantiate(pendantPrefab, position, Quaternion.identity);
            StartCoroutine(DespawnPendant(pendant, 3.0f));
        }
    }
    IEnumerator DespawnPendant(GameObject pendant, float despawnTime)
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(pendant);   // Destroy the pendant after despawnTime
    }

    IEnumerator SpawnBrowniePoint(float waitTime)
    {
        while (true)
        {
            System.Random Randomx = new System.Random();
            int x = Randomx.Next(-9, 9);
            System.Random Randomy = new System.Random();
            int y = Randomy.Next(-4, 4);

            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(x, y, -1f);
            brownie = Instantiate(browniePrefab, position, Quaternion.identity);
            StartCoroutine(DespawnBrowniePoint(brownie, 5.0f));
        }
    }
    IEnumerator DespawnBrowniePoint(GameObject brownie, float despawnTime)
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(brownie);   // Destroy the brownie point after despawnTime
    }
    
    //SPAWN PIRATE!!!
    IEnumerator SpawnPirate(float waitTime)
    {
        while (true)
        {
            System.Random Randomx = new System.Random();
            int x = Randomx.Next(-9, 9);
            System.Random Randomy = new System.Random();
            int y = Randomy.Next(-4, 4);

            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(x, y, -1f);
            pirate = Instantiate(piratePrefab, position, Quaternion.identity);
            StartCoroutine(DespawnPirate(pirate, 5.0f));
        }
    }
    IEnumerator DespawnPirate(GameObject pirate, float despawnTime)
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(pirate);    // Destroy the pirate after despawnTime
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = Unity.Mathematics.Random;

public class TokenSpawnScript : MonoBehaviour
{
    [SerializeField]
    public GameObject pendantPrefab;
    public GameObject cookbookPrefab;
    public GameObject browniePrefab;
    
    
    
    
    public GameObject piratePrefab;

    


    public GameObject brownie;
    public GameObject pirate;
    
    public PlayerPointHandler handler;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBrowniePoint(5.0f));
        StartCoroutine(SpawnPirate(2.0f));
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
            StartCoroutine(DespawnBrowniePoint(brownie, 5.0f)); // Schedule despawning 
        }
    }

    IEnumerator DespawnBrowniePoint(GameObject brownie, float despawnTime)
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(brownie); // Destroy the brownie point after despawnTime
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
            StartCoroutine(DespawnPirate(pirate, 5.0f)); // Schedule despawning 
        }
    }

    IEnumerator DespawnPirate(GameObject brownie, float despawnTime)
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(pirate); // Destroy the brownie point after despawnTime
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }
}

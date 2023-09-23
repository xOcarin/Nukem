using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawnScript : MonoBehaviour
{
    [SerializeField]
    public GameObject pendantPrefab;
    public GameObject cookbookPrefab;
    public GameObject browniePrefab;

    IEnumerator SpawnBrowniePoint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Vector3 position = new Vector3(0f, 0f, -1f);
        GameObject brownie = Instantiate(browniePrefab, position, Quaternion.identity);
        StartCoroutine(DespawnBrowniePoint(brownie, 5.0f)); // Schedule despawning
    }

    IEnumerator DespawnBrowniePoint(GameObject brownie, float despawnTime)
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(brownie); // Destroy the brownie point after despawnTime
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBrowniePoint(5.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

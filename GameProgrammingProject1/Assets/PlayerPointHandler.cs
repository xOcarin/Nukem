using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPointHandler : MonoBehaviour
{
    public int kpCounter = 0;
    public int bpCounter = 0;
    
    [SerializeField] 
    public TextMeshProUGUI kpText; 
    public TextMeshProUGUI bpText;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pendant")
        {
            kpCounter = kpCounter + 25;
            Debug.Log("YES");
            Debug.Log("Knowledge: " + kpCounter);
        }
        
        if (collision.gameObject.tag == "CookBook")
        {
            kpCounter++;
            Debug.Log("YES");
            Debug.Log("Knowledge: " + kpCounter);
        }
        
        if (collision.gameObject.tag == "BrowniePoint")
        {
            bpCounter++;
            Debug.Log("YES");
            Debug.Log("Brownie Points: " + bpCounter);
        }
    }
    
    
    void Update()
    {
        kpText.text = kpCounter.ToString();
        bpText.text = bpCounter.ToString();
    }
}



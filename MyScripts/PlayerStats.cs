using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int playerHealth = 100;
    [SerializeField] private Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + playerHealth.ToString();
        if(playerHealth <= 0)
        {
            UnityEngine.Debug.LogWarning("YOU DIED!");
        }
    }
}

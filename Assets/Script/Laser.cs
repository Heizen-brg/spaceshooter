using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
        {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            player.Damage();
        }
         if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            if (player != null)
            {
                player.AddScore(10);
            }
        } 
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

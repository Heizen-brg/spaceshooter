using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject laserPrefab;

    void Start()
    {
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
             if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            Destroy(gameObject);
            player.Damage();
        }
    }
    void Shoot()
    {
            Vector3 laserPos = new Vector3(transform.position.x, transform.position.y - 1f, 0);
            Instantiate(laserPrefab, laserPos, transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public float _speed;
    [SerializeField]
    private int powerId;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
    }
    void MoveDown ()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -5f )
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            Destroy(gameObject);
            switch (powerId)
            {
                case 0 : 
                    player.TripleShotActive();
                    break;
                case 1:
                    player.SpeedBootsActive();
                    break;
                case 2:
                    player.ProtectShieldActive();
                    break;
                default:
                    break;
            }
            ;
        }
    }
}

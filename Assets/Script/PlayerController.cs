using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject laserPrefab;
    public GameObject tripleShoot;
    public GameObject shieldUp;
    public GameObject speedUp;
    public GameObject hurtEffect;
    private UIManager uiManager;

    public int life = 3;
    public int score;
    public float _speed = 5.0f;
    private float xBound = 8f;
    private float fireRate = 0.3f;
    private float fireCoolDown = -1f;
    private float speedMulti = 2f;
    private bool isTripleShootActive = false;
    private bool isProtectShieldActive = false;
    private bool isSpeedActive = false;
    void Start()
    {
        transform.Translate(new Vector3(0, -3, 0));
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Shoot();
    }
    void Moving()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * _speed);

        if (transform.position.x >= xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, 0);
        }
        else if (transform.position.x <= -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, 0);
        }
        if (transform.position.y >= 4)
        {
            transform.position = new Vector3(transform.position.x, 4, 0);
        }
        else if (transform.position.y <= -3)
        {
            transform.position = new Vector3(transform.position.x, -3, 0);
        }
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > fireCoolDown)
        {
            fireCoolDown = Time.time + fireRate;
            Vector3 laserPos = new Vector3(transform.position.x, transform.position.y + 1.5f, 0);
            if (isTripleShootActive == true)
            {
                Instantiate(tripleShoot, laserPos, transform.rotation);
            }
            else
            {
                Instantiate(laserPrefab, laserPos, transform.rotation);
            }
        }
    }
    public void Damage()
    {
        if ( !isProtectShieldActive) life--;
        uiManager.UpdateLives(life);
        isProtectShieldActive = false;
        shieldUp.SetActive(false);
        hurtEffect.SetActive(true);
        if (life == 0)
        {
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }

    }
    public void TripleShotActive()
    {
        isTripleShootActive = true;
        StartCoroutine(TripleShotDownRoutine());
    }

    IEnumerator TripleShotDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShootActive = false;
    }

    public void SpeedBootsActive()
    {
        isSpeedActive = true;
        speedUp.SetActive(true);
        _speed *= speedMulti;
        StartCoroutine(SpeedBoostRoutine());
    }
    IEnumerator SpeedBoostRoutine()
    {

        yield return new WaitForSeconds(5.0f);
        isSpeedActive = false;
        _speed /= speedMulti;
        speedUp.SetActive(false);



    }
    public void ProtectShieldActive()
    {
        isProtectShieldActive = true;
        shieldUp.SetActive(true);
    }

    public void AddScore(int point)
    {
        score += point;
        uiManager.UpdateScore(score);
    }

}
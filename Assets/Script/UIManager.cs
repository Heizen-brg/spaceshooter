using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _score;
    [SerializeField]
    private Sprite[] _liveSprite;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartGameText;

    public Image _livesImg;
    // Start is called before the first frame update
    void Start()
    {
        _score.text = "Score:" + 0 ;
        _gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame

    public void UpdateScore (int playerScore)
    {
        _score.text = "Score:" + playerScore.ToString();
    }
    public void UpdateLives(int lives)
    {
        _livesImg.sprite = _liveSprite[lives];
        if (lives == 0)
        {
            _gameOverText.gameObject.SetActive(true);
            _restartGameText.gameObject.SetActive(true);
        StartCoroutine(gameOverFlicker());
        }
    }

    IEnumerator gameOverFlicker ()
    {
        while (true)
        {
            _gameOverText.text = "Game Over";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameover = false;
    public Text scoreText;
    public Text recordText;
    public GameObject gameOverUI;


    [SerializeField]
    private int score = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("게임매니저 두개 이상 존재");
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (isGameover && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void AddScore(int newScore)
    {
        if(!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }
    public void OnPlayerDead()
    {
        isGameover = true;
        gameOverUI.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("BestTime");
        if(score>bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("BestTime", bestScore);
        }
        recordText.text = "Best Score : " + (int)bestScore;
    }
}

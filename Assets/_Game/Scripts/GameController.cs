using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public AudioClip[] audioEnemies;
    [HideInInspector] public int totalScore, enemyCount, highscore;

    private UIController uiController;
    public Transform allEnemiesParent;

    private Spawner spawner;
    private Destroyer destroyer;

    [SerializeField] private AudioSource music;

    private void Awake()
    {
        uiController = FindObjectOfType<UIController>();
        spawner = FindObjectOfType<Spawner>();
        destroyer = FindObjectOfType<Destroyer>();
        highscore = GetScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        enemyCount = 0;
        spawner.gameObject.GetComponent<Spawner>().enabled = false;
        music.volume = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
        spawner.gameObject.GetComponent<Spawner>().enabled = false;
        destroyer.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        uiController.txtFinalScore.text = "Score: " + totalScore.ToString();

        foreach (Transform child in allEnemiesParent.transform)
        {
            Destroy(child.gameObject);
        }
    }


    public void DestroyEnemy(Collider2D target)
    {
        enemyCount++;

        if (enemyCount < 5)
        {
            uiController.imageLifes[enemyCount - 1].gameObject.SetActive(false);
        }
        else
        {
            uiController.imageLifes[enemyCount - 1].gameObject.SetActive(false);
            uiController.panelGameOver.gameObject.SetActive(true);
            GameOver();
            SaveScore();
            Debug.Log("game over");
        }
        Destroy(target.gameObject);
    }

    public void Restart()
    {
        totalScore = 0;
        enemyCount = 0;
        uiController.txtScore.text = totalScore.ToString();
        spawner.gameObject.GetComponent<Spawner>().enabled = true;
        destroyer.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        foreach (Transform child in allEnemiesParent.transform)
        {
            Destroy(child.gameObject);
        }

    }

    public void BackMainMenu()
    {
        totalScore = 0;
        enemyCount = 0;
        music.volume = 0.5f;
        uiController.txtScore.text = totalScore.ToString();
        destroyer.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        spawner.gameObject.GetComponent<Spawner>().enabled = false;

        for(int i = 0; i < uiController.imageLifes.Length; i++)
        {
            uiController.imageLifes[i].gameObject.SetActive(true);
        }

        foreach (Transform child in allEnemiesParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void StartGame()
    {
        totalScore = 0;
        enemyCount = 0;
        uiController.txtScore.text = totalScore.ToString();
        spawner.gameObject.GetComponent<Spawner>().enabled = true;
        music.volume = 0.25f;
    }

    public void SaveScore()
    {
        if (totalScore > highscore)
        {
            PlayerPrefs.SetInt("highscore", totalScore);
            uiController.txtHighscore.text = "Highscore: " + totalScore.ToString();
        }
    }

    public int GetScore()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        return highscore;
    }

}

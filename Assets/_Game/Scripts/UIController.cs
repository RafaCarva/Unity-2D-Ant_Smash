using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    public TMP_Text txtScore;
    public Image[] imageLifes;

    public GameObject panelGame, panelPause;

    // Start is called before the first frame update
    void Start()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore (int score)
    {
        txtScore.text = score.ToString();
    }

    public void ButtonPause()
    {
        Time.timeScale = 0f;
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
    }

    public void ButtonResume()
    {
        Time.timeScale = 1f;
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
    }

    public void ButtonBackMainMenu()
    {
        Time.timeScale = 1f;
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
    }

}

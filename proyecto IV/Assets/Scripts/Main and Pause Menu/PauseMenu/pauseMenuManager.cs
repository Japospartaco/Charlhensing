using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenuManager : MonoBehaviour
{
    private bool paused;
    public GameObject PauseCanvas;
    public GameObject GameOverCanvas;
    public GameObject WinCanvas;
    public int remaining;

    private void Start()
    {
        PauseCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        WinCanvas.SetActive(false);
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerHPManager>().PlayerHit += GameOver;

        GameObject pool = GameObject.FindWithTag("GameManager");

        pool.GetComponent<Spawner>()._enemyPool.EnemyDead += EnemyDead;
    }

    private void GameOver(object sender, int hp)
    {
        if(hp <= 0)
        {
            Time.timeScale = 0;
            GameOverCanvas.SetActive(true);
            PauseCanvas.SetActive(false);   
            paused = true;
        }
    }

    public void resetScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    private void Update()
    {    
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (paused == false)
            {
                Time.timeScale = 0;
                PauseCanvas.SetActive(true);
                paused = true;
            }
            else
            {
                Time.timeScale = 1;
                PauseCanvas.SetActive(false);
                paused = false;
            }
            
        }
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
        paused = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    private void EnemyDead(object sender, int nothings)
    {
        remaining--;
        if(remaining <= 0)
        {
            Time.timeScale = 0;
            WinCanvas.SetActive(true);
            PauseCanvas.SetActive(false);
            GameOverCanvas.SetActive(false);
            paused = true;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject canvasTutorial;
    public GameObject mainCanvas;

    public void Start()
    {
        canvasTutorial.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Tutorial()
    {
        mainCanvas.SetActive(false);
        canvasTutorial.SetActive(true);
    }


    public void ReturnFromTut()
    {
        mainCanvas.SetActive(true);
        canvasTutorial.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

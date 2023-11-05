using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [Header("PauseMenu")] 
    public GameObject AnaMenu;
    public GameObject PauseMenu;
    [Header("AnaMenuu")] 
    [Header("Music")] private int b;



    public void TogglePauseMenu()
    {
        PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        //TODO Sahne yeniden yuklenince en bastan baslamasi lazim
    }
}

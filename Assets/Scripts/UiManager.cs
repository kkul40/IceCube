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


    public AudioClip TogglePauseSound;
    public AudioClip RestartGameSound;
    public AudioClip MainMenuSound;


    public void ToggleMusicOnOff()
    {
        MusicManager.instance.ToggleMusic();
    }

    public void TogglePauseMenu()
    {
        MusicManager.instance.PlayAudio(TogglePauseSound);
        PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
    }

    public void LoadMainMenu()
    {
        MusicManager.instance.PlayAudio(MainMenuSound);
        StartCoroutine(LoadScene(0));
        SaveManager.instance.SaveGame();
    }

    public void RestartGame()
    {
        //TODO Sahne yeniden yuklenince en bastan baslamasi lazim

        MusicManager.instance.PlayAudio(RestartGameSound);
        StartCoroutine(LoadScene(1));
        SaveManager.instance.SaveGame();
    }

    IEnumerator LoadScene(int a)
    {
        SaveManager.instance.SaveGame();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(a);
    }
}

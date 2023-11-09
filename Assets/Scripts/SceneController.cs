using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public AudioClip startSound;
   
    public void StartScene()
    {
        MusicManager.instance.PlayAudio(startSound);
        
        Invoke(nameof(LoadScene),0.5f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("Scenes/Game");
    }
    
}

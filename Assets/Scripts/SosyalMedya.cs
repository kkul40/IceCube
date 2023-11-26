using UnityEngine;
using UnityEngine.UI;

public class SosyalMedya : MonoBehaviour
{
    public string discordLink;
    public string tiktokLink;
    public string �nstagramLink;
    public string youtubeLink;
    // Di�er sosyal medya linklerini ekleyebilirsiniz.


    public void OpenDiscordLink()
    {
        Application.OpenURL(discordLink);
    }

    public void OpenTiktokLink()
    {
        Application.OpenURL(tiktokLink);
    }

    public void OpenInstagramLink()
    {
        Application.OpenURL(�nstagramLink);
    }
    public void OpenYoutubeLink()
    {
        Application.OpenURL(youtubeLink);
    }
}

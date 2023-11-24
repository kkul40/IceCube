using UnityEngine;
using UnityEngine.UI;

public class SosyalMedya : MonoBehaviour
{
    public string discordLink;
    public string tiktokLink;
    public string ýnstagramLink;
    public string youtubeLink;
    // Diðer sosyal medya linklerini ekleyebilirsiniz.


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
        Application.OpenURL(ýnstagramLink);
    }
    public void OpenYoutubeLink()
    {
        Application.OpenURL(youtubeLink);
    }
}

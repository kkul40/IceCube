using UnityEngine;
using UnityEngine.UI;

public class SosyalMedya : MonoBehaviour
{
    public string discordLink;
    public string tiktokLink;
    public string ınstagramLink;
    public string youtubeLink;
    // Diğer sosyal medya linklerini ekleyebilirsiniz.


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
        Application.OpenURL(ınstagramLink);
    }
    public void OpenYoutubeLink()
    {
        Application.OpenURL(youtubeLink);
    }
}

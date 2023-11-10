using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpensUrl : MonoBehaviour
{
    public void OpenInstagram()
    {
        Application.OpenURL("https://instagram.com/celikgames?igshid=MWhuZ2gxbDhuMjZ5Zg%3D%3D&utm_source=qr");
    }
    public void OpenTiktok()
    {
        Application.OpenURL("https://www.tiktok.com/@celikgamesstudio?lang=tr-TR");
    }
    public void OpenDiscord()
    {
        Application.OpenURL("https://discord.gg/6reRRf3GTC");
    }
    public void OpenYoutube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCedWxjn5osslO7RBkfAp0HQ");
    }
}

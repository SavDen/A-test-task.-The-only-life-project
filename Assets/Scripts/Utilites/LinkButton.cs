using UnityEngine;

public class LinkButtonStore: MonoBehaviour
{
    public void Link (string url)
    {
        Application.OpenURL(url);
    }
}

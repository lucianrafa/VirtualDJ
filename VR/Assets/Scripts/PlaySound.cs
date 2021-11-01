using UnityEngine;

public class PlaySound : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.PlayWithCheck("Song");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip titleMusic;
    
    public void ClickAndLoad()
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip, 0.8F);
        }

        Invoke("LoadGame", 0.3f);
    }

    public void LoadGame() {
        SceneManager.LoadScene("Buildings");
    }
}

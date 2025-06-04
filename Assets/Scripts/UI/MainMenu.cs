using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void ClickAndLoad() {
        Invoke("LoadGame", 0.3f);
    }

    public void LoadGame() {
        SceneManager.LoadScene("SampleScene");
    }
}

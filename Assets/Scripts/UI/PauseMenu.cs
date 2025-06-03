using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour, IMenu
{
    public GameObject pauseMenu;
    public AudioSource audioSource;
    public AudioClip menuToggle;
    public AudioClip buttonClick;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PlaceBuilding.Instance.isPlacing)
        {
            if (!MenuManager.IsAnyMenuOpen())
            {
                MenuManager.OpenOverlayMenu(this);
                PlaySound(menuToggle);
            }
            else
            {
                MenuManager.CloseOverlayMenu();
                PlaySound(menuToggle);
            }
        }
    }

    public void Open()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        PlaySound(menuToggle);
    }

    public void Close()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        PlaySound(menuToggle);
    }

    public void ClickAndLoadMainMenu()
    {
        Time.timeScale = 1;
        PlaySound(buttonClick);
        Invoke("LoadMainMenu", 0.3f);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
    private void PlaySound(AudioClip clip) {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}

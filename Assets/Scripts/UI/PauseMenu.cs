using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            Pause();
        }
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ClickAndLoadMainMenu() {
        Time.timeScale = 1;
        Invoke("LoadMainMenu", 0.3f);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}

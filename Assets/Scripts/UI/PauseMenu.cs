using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour, IMenu
{
    public GameObject pauseMenu;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !PlaceBuilding.Instance.isPlacing)
        {
            if (!MenuManager.IsAnyMenuOpen())
            {
                MenuManager.OpenOverlayMenu(this); ;
            }
            else
            {
                MenuManager.CloseOverlayMenu();
            }
        }
    }

    public void Open() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close() {
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

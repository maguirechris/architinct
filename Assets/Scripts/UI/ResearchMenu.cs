using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ResearchMenu : MonoBehaviour
{
    public GameObject researchMenu;
    public GameObject tileMap;
    public GameObject resources;

    void Update() {
        if (Input.GetKey(KeyCode.R)) {
            openMenu();
        }
    }

    public void openMenu()
    {
        researchMenu.SetActive(true);
        tileMap.SetActive(false);
        resources.SetActive(false);
        Time.timeScale = 0;
        
    }

    public void closeMenu() {
        researchMenu.SetActive(false);
        tileMap.SetActive(true);
        resources.SetActive(true);
        Time.timeScale = 1;
    }
}

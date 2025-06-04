using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ResearchMenu : MonoBehaviour, IMenu
{
    public GameObject researchMenu;
    public GameObject tileMap;
    public GameObject resources;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!MenuManager.IsPrimaryMenuOpen())
            {
                MenuManager.OpenPrimaryMenu(this);
            }
            else
            {
                MenuManager.ClosePrimaryMenu();
            }
        }
    }

    public void Open()
    {
        researchMenu.SetActive(true);
        tileMap.SetActive(false);
        resources.SetActive(false);
        Time.timeScale = 0;
    }

    public void Close()
    {
        researchMenu.SetActive(false);
        tileMap.SetActive(true);
        resources.SetActive(true);
        Time.timeScale = 1;
    }

    public void OnResearchButtonPressed()
    {
        if (!MenuManager.IsAnyMenuOpen() || !MenuManager.GetCurrentPrimaryMenu().Equals(this))
        {
            MenuManager.OpenPrimaryMenu(this);
        }
        else
        {
            MenuManager.ClosePrimaryMenu();
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BuildingMenu : MonoBehaviour, IMenu
{
    public GameObject buildingMenu;
    public GameObject tileMap;
    public GameObject resources;
    public static BuildingMenu Instance;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
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
        buildingMenu.SetActive(true);
        tileMap.SetActive(false);
        resources.SetActive(false);
        Time.timeScale = 0;
    }

    public void Close()
    {
        buildingMenu.SetActive(false);
        tileMap.SetActive(true);
        resources.SetActive(true);
        Time.timeScale = 1;
    }

    public void OnBuildingButtonPressed()
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

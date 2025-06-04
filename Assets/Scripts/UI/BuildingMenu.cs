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
    public AudioSource audioSource;
    public AudioClip menuToggle;

    void Start()
    {
        if (Instance == null)
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
                PlaySound(menuToggle);
            }
            else
            {
                MenuManager.ClosePrimaryMenu();
                PlaySound(menuToggle);
            }
        }
    }

    public void Open()
    {
        buildingMenu.SetActive(true);
        tileMap.SetActive(false);
        resources.SetActive(false);
        Time.timeScale = 0;
        PlaySound(menuToggle);
    }

    public void Close()
    {
        buildingMenu.SetActive(false);
        tileMap.SetActive(true);
        resources.SetActive(true);
        Time.timeScale = 1;
        PlaySound(menuToggle);
    }

    public void OnBuildingButtonPressed()
    {
        if (!MenuManager.IsAnyMenuOpen() || !MenuManager.GetCurrentPrimaryMenu().Equals(this))
        {
            MenuManager.OpenPrimaryMenu(this);
            PlaySound(menuToggle);
        }
        else
        {
            MenuManager.ClosePrimaryMenu();
            PlaySound(menuToggle);
        }
    }
    
    private void PlaySound(AudioClip clip) {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}

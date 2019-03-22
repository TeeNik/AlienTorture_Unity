using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    GameObject currentPage;
    public GameObject[] pages;
    void Start()
    {
        currentPage = pages[0];   
    }

    void Update()
    {
        
    }
    public void OpenPage(int i)
    {
        currentPage.SetActive(false);
        currentPage = pages[i];
        currentPage.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

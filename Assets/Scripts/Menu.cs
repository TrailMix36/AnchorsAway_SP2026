/*****************************************************************************
// File Name : Menu.cs
// Author : Simon Bruening-Wright
// Creation Date : 4/21/2026
//
// Brief Description : Handles the main menu
*****************************************************************************/

using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject controlMenu;
    /// <summary>
    /// Quits the game when called
    /// </summary>
    public void End()
    {
        Application.Quit();
    }
    /// <summary>
    /// Leaves the controls menu when called
    /// </summary>
    public void Back()
    {
        controlMenu.SetActive(false); 
    }
    /// <summary>
    /// Opens the controls menu when called
    /// </summary>
    public void Controls()
    {
        controlMenu.SetActive(true);
    }
}

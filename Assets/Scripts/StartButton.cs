/*****************************************************************************
// File Name : StartButton.cs
// Author : Simon Bruening-Wright
// Creation Date : 3/26/2026
//
// Brief Description : Functionality for the start buttton
*****************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    /// <summary>
    /// Loads the Surface scene
    /// </summary>
    public void Begin()
    {
        SceneManager.LoadScene(0);
    }
}

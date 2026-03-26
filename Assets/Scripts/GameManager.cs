/*****************************************************************************
// File Name : GameManager.cs
// Author : Simon Bruening-Wright
// Creation Date : 3/26/2026
//
// Brief Description : Game manager for keeping track of scene management
*****************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance; 
    /// <summary>
    /// Makes sure that this game manager doesnt destroy on load and that there is only one game manager
    /// </summary>
    void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject); 
        }
        else
        {
            Instance = this; 
            DontDestroyOnLoad(this.gameObject);
        }
    }
    /// <summary>
    /// Changes the scene to underwater
    /// </summary>
    public void Dive()
    {
        SceneManager.LoadScene(1);
    }
    /// <summary>
    /// Changes the scene to the surface
    /// </summary>
    public void Surface()
    {
        SceneManager.LoadScene(0);
    }
}

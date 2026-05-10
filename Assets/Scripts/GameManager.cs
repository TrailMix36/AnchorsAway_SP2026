/*****************************************************************************
// File Name : GameManager.cs
// Author : Simon Bruening-Wright
// Creation Date : 3/26/2026
//
// Brief Description : Game manager for keeping track of scene management
*****************************************************************************/


using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public static int Fish;
    public static int Money;
    public static int Debt = 50;
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

    private void Start()
    {
        
    }
    /// <summary>
    /// Changes the scene to underwater
    /// </summary>
    public void Dive()
    {
        SceneManager.LoadScene(2);
        
    }
    /// <summary>
    /// Changes the scene to the surface
    /// </summary>
    public void Surface()
    {
        SceneManager.LoadScene(1);
        
    }

    public void AddFish()
    {
        Fish ++;
    }
    public void SellFish()
    {
        Money += Fish;
        Fish = 0;
    }

    public void PayDebt()
    {
        if(Debt >= Money)
        {
            Debt -= Money;
            Money = 0;
        }
        if(Debt < Money)
        {
            Money -= Debt;
            Debt = 0;
        }
    }
}

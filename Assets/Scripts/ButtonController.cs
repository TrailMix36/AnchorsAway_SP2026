/*****************************************************************************
// File Name : ButtonController.cs
// Author : Simon Bruening-Wright
// Creation Date : 3/26/2026
//
// Brief Description : Allows the functionality of the dive and surface buttons
*****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;
public class ButtonController : MonoBehaviour
{
    
    /// <summary>
    /// Sets the functionality on the button click depending on which scene you are in
    /// </summary>
    void Start()
    {
         
        Button button = GetComponent<Button>();
        if (button != null && SceneManager.GetActiveScene().buildIndex == 0)
        {
            // Add a runtime listener that calls the singleton's function
            button.onClick.AddListener(() => GameManager.Instance.Dive());
        }
        else
        {
            button.onClick.AddListener(() => GameManager.Instance.Surface());
        }
    }

    
}

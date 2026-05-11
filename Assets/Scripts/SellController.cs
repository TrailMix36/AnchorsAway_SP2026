/*****************************************************************************
// File Name : SellController.cs
// Author : Simon Bruening-Wright
// Creation Date : 5/10/2026
//
// Brief Description : Makes the sell button work
*****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
public class SellController : MonoBehaviour
{
    /// <summary>
    /// Allows the sell button to be pressed
    /// </summary>
    private void Start()
    {
        Button button = GetComponent<Button>();
        if(button != null)
        {
            button.onClick.AddListener(() => GameManager.Instance.SellFish());
        }
        
    }
}

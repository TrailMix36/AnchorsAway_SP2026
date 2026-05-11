/*****************************************************************************
// File Name : DebtController.cs
// Author : Simon Bruening-Wright
// Creation Date : 5/10/2026
//
// Brief Description : Controls the debt button
*****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
public class DebtController : MonoBehaviour
{
    /// <summary>
    /// Allows the debt button to work
    /// </summary>
    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => GameManager.Instance.PayDebt());
        }
    }
}

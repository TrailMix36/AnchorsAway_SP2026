/*****************************************************************************
// File Name : ScoreDisplay.cs
// Author : Simon Bruening-Wright
// Creation Date : 5/10/2026
//
// Brief Description : Gets the fish, money, and debt variables from the game manager and puts them on the screen
*****************************************************************************/

using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text fishText;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text debtText;
    [SerializeField] private GameObject winScreen;
    private int fish;
    private int money;
    private int debt;
    /// <summary>
    /// sets the text variables
    /// </summary>
    void Start()
    {
        fishText = GameObject.Find("Fish").GetComponent<TMP_Text>();
        moneyText = GameObject.Find("Money").GetComponent<TMP_Text>();
        debtText = GameObject.Find("Debt").GetComponent<TMP_Text>();
    }

    /// <summary>
    /// Updates the text on screen and checks for the win condition
    /// </summary>
    void Update()
    {
        fish = GameManager.Fish;
        money = GameManager.Money;
        debt = GameManager.Debt;
        fishText.text = "Fish: " + fish.ToString();
        moneyText.text = "Money: " + money.ToString();
        debtText.text = "Debt: " + debt.ToString();
        if(debt == 0)
        {
            winScreen.SetActive(true);
        }
    }
}

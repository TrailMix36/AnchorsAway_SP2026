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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fishText = GameObject.Find("Fish").GetComponent<TMP_Text>();
        moneyText = GameObject.Find("Money").GetComponent<TMP_Text>();
        debtText = GameObject.Find("Debt").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
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

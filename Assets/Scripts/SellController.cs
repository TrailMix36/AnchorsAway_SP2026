using UnityEngine;
using UnityEngine.UI;
public class SellController : MonoBehaviour
{
    private void Start()
    {
        Button button = GetComponent<Button>();
        if(button != null)
        {
            button.onClick.AddListener(() => GameManager.Instance.SellFish());
        }
        
    }
}

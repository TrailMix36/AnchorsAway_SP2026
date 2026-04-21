using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject controlMenu;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void End()
    {
        Application.Quit();
    }
    public void Back()
    {
        controlMenu.SetActive(false); 
    }

    public void Controls()
    {
        controlMenu.SetActive(true);
    }
}

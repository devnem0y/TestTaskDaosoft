using UnityEngine;
using UralHedgehog.UI;

public class EntryPoint : MonoBehaviour
{
    public static EntryPoint Instance { get; private set;}
    
    public bool IsGamePaused { get; private set; }
    
    private UIManager _uiManager;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        
        if (IsGamePaused)
        {
            Time.timeScale = 1;
            IsGamePaused = false;
        }
        else
        {
            Time.timeScale = 0;
            IsGamePaused = true;
        }
    }
}

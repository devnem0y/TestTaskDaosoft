using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UralHedgehog.UI;

public class EntryPoint : MonoBehaviour
{
    public static EntryPoint Instance { get; private set;}
    
    public bool IsGamePaused { get; private set; }
    public event Action<bool> OnGamePaused;
    
    //TODO: Не самый лучший подход, чтобы доставать его по инстанцу, но для тестового задания пойдет
    [SerializeField] private Config _config;
    public Config Config => _config;
    
    private UIManager _uiManager;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _uiManager = new UIManager(FindObjectOfType<UIRoot>());
        
        _uiManager.OpenViewTopPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                Time.timeScale = 1;
                IsGamePaused = false;
                OnGamePaused?.Invoke(IsGamePaused);
            }
            else
            {
                Time.timeScale = 0;
                IsGamePaused = true;
                OnGamePaused?.Invoke(IsGamePaused);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #endif
            
            Application.Quit();
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            IsGamePaused = false;
            OnGamePaused?.Invoke(IsGamePaused);
            
            SceneManager.LoadScene(0);
        }
    }
}

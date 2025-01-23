using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            }
            else
            {
                Time.timeScale = 0;
                IsGamePaused = true;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #endif
            
            Application.Quit();
        }
        
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene(0);
        }
    }
}

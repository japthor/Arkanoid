using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  // Reference to GameManager
  private static GameManager m_Instance;
  // Reference to GameManagerElements
  private GameManagerElements m_GameManagerElements;
  // Reference to InputManager
  private InputManager m_InputManager;
  // Reference to ScenesManager
  private ScenesManager m_ScenesManager;

  // Setters/Getters
  public static GameManager Instance
  {
    get { return m_Instance; }
    private set { Instance = value; }
  }
  public GameManagerElements GameManagerElements
  {
    get { return m_GameManagerElements; }
    private set { m_GameManagerElements = value; }
  }
  public InputManager InputManager
  {
    get { return m_InputManager; }
    private set { m_InputManager = value; }
  }

  private void Awake()
  {
    if (m_Instance == null)
    {
      m_Instance = this;
      DontDestroyOnLoad(gameObject);

      m_ScenesManager = new ScenesManager();
      m_GameManagerElements = new GameManagerElements();
      m_InputManager = new InputManager();

    }
    else
      Destroy(this);
  }

  private void OnEnable()
  {
    if(m_InputManager != null)
      m_InputManager.Enable();

    if(m_GameManagerElements != null)
    {
      m_GameManagerElements.LoseEvent += GameOver;
      m_GameManagerElements.WinEvent += Win;
    }
  }

  private void OnDisable()
  {
    if (m_InputManager != null)
      m_InputManager.Disable();

    if (m_GameManagerElements != null)
    {
      m_GameManagerElements.LoseEvent -= GameOver;
      m_GameManagerElements.WinEvent -= Win;
    }
  }

  // Logic for when the player wins.
  private void Win()
  {
    if(m_ScenesManager != null)
      m_ScenesManager.NextScene();
  }
  // Logic for when the player loses.
  private void GameOver()
  {
    if (m_ScenesManager != null)
      m_ScenesManager.LoadMainMenu();

    if (m_GameManagerElements != null)
      m_GameManagerElements.ResetValues();
  }
}

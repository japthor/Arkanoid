using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
  // Reference to the ScenesManager
  private ScenesManager m_ScenesManager;

  private void Awake()
  {
    m_ScenesManager = new ScenesManager();
  }

  // Plays the Game.
  public void Play()
  {
    if(m_ScenesManager != null)
    {
      GameManager.Instance.GameManagerElements.ResetValues();
      m_ScenesManager.NextScene();
    }
  }
  // Exits the Game.
  public void Exit()
  {
    Application.Quit();
  }
}

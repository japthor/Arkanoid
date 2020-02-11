using TMPro;
using UnityEngine;

public class UIWinMenu : MonoBehaviour
{
  // Reference to ScenesManager
  private ScenesManager m_ScenesManager;
  // Reference to the Score Text.
  [SerializeField] private TextMeshProUGUI m_Score = null;
  // Reference to the Life Text.
  [SerializeField] private TextMeshProUGUI m_Life = null;

  private void Awake()
  {
    m_ScenesManager = new ScenesManager();
  }
  private void Start()
  {
    UpdateScore();
    UpdateLife();
  }
  // Updates the score.
  private void UpdateScore()
  {
    if (m_Score != null)
      m_Score.text = GameManager.Instance.GameManagerElements.Score.ToString();
  }
  // Updates the life.
  private void UpdateLife()
  {
    if (m_Life != null)
      m_Life.text = GameManager.Instance.GameManagerElements.Life.ToString();
  }
  // Returns to the Main Menu.
  public void Return()
  {
    if(m_ScenesManager != null)
      m_ScenesManager.LoadMainMenu();
  }
}

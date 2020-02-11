using TMPro;
using UnityEngine;

public class UIGame : MonoBehaviour
{
  // Reference to the Score Text.
  [SerializeField] private TextMeshProUGUI m_Score = null;
  // Reference to the Life Text.
  [SerializeField] private TextMeshProUGUI m_Life = null;

  private void Start()
  {
    UpdateScore();
    UpdateLife();
  }
  private void OnEnable()
  {
    GameManager.Instance.GameManagerElements.LifeEvent += UpdateLife;
    GameManager.Instance.GameManagerElements.ScoreEvent += UpdateScore;
  }
  private void OnDisable()
  {
    GameManager.Instance.GameManagerElements.LifeEvent -= UpdateLife;
    GameManager.Instance.GameManagerElements.ScoreEvent -= UpdateScore;
  }

  // Updates the score.
  private void UpdateScore()
  {
    if(m_Score != null)
      m_Score.text = GameManager.Instance.GameManagerElements.Score.ToString();
  }
  // Updates the life.
  private void UpdateLife()
  {
    if (m_Life != null)
      m_Life.text = GameManager.Instance.GameManagerElements.Life.ToString();
  }
}

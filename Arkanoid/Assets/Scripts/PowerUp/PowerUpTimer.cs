using System.Collections;
using UnityEngine;

public class PowerUpTimer : MonoBehaviour
{
  // Duration of the power up. 
  [SerializeField] private float m_Timer;
  // Actual current time.
  private float m_CurrentTime;

  // Events for when the Timer starts/ends.
  public delegate void PowerUpTimerDelegate();
  public event PowerUpTimerDelegate StartTimer;
  public event PowerUpTimerDelegate EndedTimer;

  // Setters/Getters.
  public float Timer
  {
    get { return m_Timer; }
    private set { m_Timer = value; }
  }
  public float CurrentTime
  {
    get { return m_CurrentTime; }
    private set { m_CurrentTime = value; }
  }

  // Start Logic.
  public void InitStart()
  {
    m_CurrentTime = m_Timer;
  }
  // Coroutine for the time (Events call).
  public IEnumerator CountDown()
  {
    StartTimer();

    while (m_CurrentTime > 0)
    {
      yield return new WaitForSeconds(1.0f);
      m_CurrentTime--;
    }

    EndedTimer();
  }
}


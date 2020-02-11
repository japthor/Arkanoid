using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerElements
{
  // Maximum life.
  private int m_MaxLife;
  // Actual life of the player.
  private int m_Life;
  // Total Score
  private int m_Score;
  // List of destructible bricks in the scene.
  private List<Brick> m_Bricks;

  // Setters/Getters
  public int MaxLife
  {
    get { return m_MaxLife; }
    private set { m_MaxLife = value; }
  }
  public int Life
  {
    get { return m_Life; }
    private set { m_Life = value; }
  }
  public int Score
  {
    get { return m_Score; }
    private set { m_Score = value; }
  }
  public List<Brick> Bricks
  {
    get { return m_Bricks; }
    private set { m_Bricks = value; }
  }

  // Event for when the Life/Score changes.
  public delegate void UIDelegate();
  public event UIDelegate ScoreEvent;
  public event UIDelegate LifeEvent;

  // Event for when the player wins/loses.
  public delegate void GameManagerDelegate();
  public event GameManagerDelegate WinEvent;
  public event GameManagerDelegate LoseEvent;

  public GameManagerElements()
  {
    Bricks = new List<Brick>();
    m_MaxLife = 3;
    ResetValues();
  }

  // Ads points to the score.
  public void AddScore(int value)
  {
    m_Score += value;
    ScoreEvent();
  }
  // Subtract points to the score.
  public void SubtractScore(int value)
  {
    if ((m_Score - value) < 0)
      m_Score = 0;
    else
      m_Score -= value;

    ScoreEvent();
  }
  // Subtract lifes.
  public void SubtractLife(int value)
  {
    if ((m_Life - value) < 0)
    {
      m_Life = 0;
      LoseEvent();
    }
    else
      m_Life -= value;

    LifeEvent();
  }
  // Add a brick to the list.
  public void AddBrick(Brick brick)
  {
    if (!m_Bricks.Contains(brick))
      m_Bricks.Add(brick);
  }
  // Subtract a brick from the list.
  public void EliminateBrick(Brick brick)
  {
    if (m_Bricks.Contains(brick))
    {
      m_Bricks.Remove(brick);

      if (EliminatedAllBricks())
        WinEvent();
    }
  }
  // Checks if there are destructible bricks left.
  private bool EliminatedAllBricks()
  {
    if (m_Bricks.Count == 0)
      return true;

    return false;
  }
  // Resets the values.
  public void ResetValues()
  {
    m_Score = 0;
    m_Life = m_MaxLife;
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
  // Speed movement of the paddle.
  [SerializeField] private float m_Velocity;

  // Setters/Getters
  public float Velocity
  {
    get { return m_Velocity; }
    private set { m_Velocity = value; }
  }

  // Update method.
  public void Tick()
  {
    Movement();
  }
  // Increases the velocity of the paddle.
  public void IncreaseVelocity(float velocity)
  {
    Velocity += velocity;
  }
  // Reduces the velocity of the paddle.
  public void ReduceVelocity(float velocity)
  {
    if ((Velocity - velocity) < 0.0f)
      Velocity = 0.0f;
    else
      Velocity -= velocity;
  }
  // Movement Logic.
  private void Movement()
  {
    transform.Translate(GameManager.Instance.InputManager.Axis * m_Velocity * Time.deltaTime);
  }
}

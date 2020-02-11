using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PaddleMovement))]
public class Paddle : MonoBehaviour
{
  // Reference to PaddleMovement
  private PaddleMovement m_PaddleMovement;
  // Size of the paddle (Width)
  private float m_SizeX;
  // Reference to the Ball;
  private Ball m_Ball;

  // Setters/Getters
  public PaddleMovement PaddleMovement
  {
    get { return m_PaddleMovement; }
    private set { m_PaddleMovement = value; }
  }
  public float SizeX
  {
    get { return m_SizeX; }
    private set { m_SizeX = value; }
  }

  private void Awake()
  {
    m_PaddleMovement = GetComponent<PaddleMovement>();
    m_SizeX = GetComponent<Renderer>().bounds.size.x;
  }

  private void Update()
  {
    m_PaddleMovement.Tick();
  }
  private void OnCollisionEnter(Collision collision)
  {
    if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ball"))
    {
      GetBall(collision.gameObject);
      ImpulseBall();
    }
  }
  // Impulses the ball
  private void ImpulseBall()
  {
    if (m_Ball != null)
    {
      //Impulses the ball depending on where it has collisioned.
      m_Ball.BallMovement.SwapDirection(gameObject, SizeX);
      //Adds velocity.
      m_Ball.BallMovement.AddVelocity();
    }
  }
  // Gets the Ball.
  private void GetBall(GameObject go)
  {
    if (m_Ball == null || go != m_Ball.gameObject)
      m_Ball = go.GetComponent<Ball>();
  }
}

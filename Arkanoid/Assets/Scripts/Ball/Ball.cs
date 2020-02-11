using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallMovement))]
public class Ball : MonoBehaviour
{
  // Reference to the movement script.
  private BallMovement m_BallMovement;

  // Setters/Getters
  public BallMovement BallMovement
  {
    get { return m_BallMovement; }
    private set { m_BallMovement = value; }
  }

  private void Awake()
  {
    m_BallMovement = GetComponent<BallMovement>();
  }
  private void Update()
  {
    m_BallMovement.Tick();
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Scene"))
    {
      if (m_BallMovement != null)
        m_BallMovement.SwapDirection(collision.gameObject);
    }
  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer == LayerMask.NameToLayer("Dead Zone"))
    {
      // -1 to the life
      GameManager.Instance.GameManagerElements.SubtractLife(1);

      // Resets the position/velocity of the ball.
      if(m_BallMovement != null)
        m_BallMovement.Resest();
    }
  }
}

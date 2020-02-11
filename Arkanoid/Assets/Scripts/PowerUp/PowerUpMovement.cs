using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
  // Movement speed when it falls.
  [SerializeField] private float m_Velocity;

  // Setters/Getters
  public float Velocity
  {
    get { return m_Velocity; }
    private set { m_Velocity = value; }
  }

  // Update Logic.
  public void Tick()
  {
    Fall();
  }
  // Movement Logic.
  private void Fall()
  {
    transform.Translate(Vector3.down * m_Velocity * Time.deltaTime);
  }
}

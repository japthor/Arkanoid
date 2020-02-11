using UnityEngine;

public class BallMovement : MonoBehaviour
{
  // Initial Velocity.
  [SerializeField] private float m_InitialVelocity;
  // Initial Direction.
  [SerializeField] private Vector3 m_InitialDirection;
  // How much will increase the velocity of the ball after colliding with the paddle.
  [SerializeField] private float m_IncreaseVelocity;
  // Initial Position.
  private Vector3 m_InitialPosition;
  // Actual Direction.
  private Vector3 m_Direction;
  // Actual Velocity.
  private float m_Velocity;

  // Setters and Getters
  public float InitialVelocity
  {
    get { return m_InitialVelocity; }
    private set { m_InitialVelocity = value; }
  }
  public Vector3 InitialDirection
  {
    get { return m_InitialDirection; }
    private set { m_InitialDirection = value; }
  }
  public float IncreaseVelocity
  {
    get { return m_IncreaseVelocity; }
    private set { m_IncreaseVelocity = value; }
  }
  public Vector3 InitialPosition
  {
    get { return m_InitialPosition; }
    private set { m_InitialPosition = value; }
  }
  public Vector3 Direction
  {
    get { return m_Direction; }
    private set { m_Direction = value; }
  }
  public float Velocity
  {
    get { return m_Velocity; }
    private set { m_Velocity = value; }
  }

  private void Start()
  {
    m_InitialPosition = transform.position;
    m_Velocity = m_InitialVelocity;
    m_Direction = m_InitialDirection;
  }
  // Update Function
  public void Tick()
  {
    Movement();
  }
  // Adds Velocity
  public void AddVelocity()
  {
    m_Velocity += m_IncreaseVelocity;
  }
  // Resets Velocity and the position.
  public void Resest()
  {
    transform.position = m_InitialPosition;
    m_Velocity = m_InitialVelocity;
  }
  // Movement of the ball.
  private void Movement()
  {
    transform.Translate(Direction * Velocity * Time.deltaTime);
  }
  // Swaps the direction of the ball depending of the hitted area.
  public void SwapDirection(GameObject object_hit)
  {
    RaycastHit MyRayHit;
    Vector3 direction = (object_hit.transform.position - transform.position).normalized;
    Ray MyRay = new Ray(transform.position, direction);

    if (Physics.Raycast(MyRay, out MyRayHit))
    {
      if (MyRayHit.collider != null)
      {

        Vector3 MyNormal = MyRayHit.normal;
        MyNormal = MyRayHit.transform.TransformDirection(MyNormal);

        Vector3 dir = m_Direction;

        if (MyNormal == MyRayHit.transform.up || MyNormal == -MyRayHit.transform.up)
          dir.y *= -1.0f;
        else if (MyNormal == MyRayHit.transform.right || MyNormal == -MyRayHit.transform.right)
          dir.x *= -1.0f;

        m_Direction = dir;
      }
    }
  }
  // Swaps the direction of the ball depending of the hitted x area.
  public void SwapDirection(GameObject object_hit, float size)
  {
    float pos = (transform.position.x - object_hit.transform.position.x) / size;
    m_Direction = new Vector3(pos, 1.0f, 0.0f).normalized;
  }
}

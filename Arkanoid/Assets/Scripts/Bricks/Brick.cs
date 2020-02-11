using UnityEngine;

[RequireComponent(typeof(BrickPowerUpSpawner))]
public class Brick : MonoBehaviour
{
  // Checks if the brick can be destroyed
  [SerializeField] private bool m_IsDestructible;
  // Max hits before breaking.
  [SerializeField] private int m_MaxHits;
  // Points for destroying the brick.
  [SerializeField] private int m_Points;
  // Reference to BrickPowerUpSpawner.
  BrickPowerUpSpawner m_BrickPowerUpSpawner;
  // Quantity of Hits taken from the ball.
  private int m_Hits;
  // Reference to the Ball;
  private Ball m_Ball;

  // Setters and Getters.
  public bool IsDestructible
  {
    get { return m_IsDestructible; }
    private set { m_IsDestructible = value; }
  }
  public int MaxHits
  {
    get { return m_MaxHits; }
    private set { m_MaxHits = value; }
  }
  public int Points
  {
    get { return m_Points; }
    private set { m_Points = value; }
  }
  public BrickPowerUpSpawner BrickPowerUpSpawner
  {
    get { return m_BrickPowerUpSpawner; }
    private set { m_BrickPowerUpSpawner = value; }
  }
  public int Hits
  {
    get { return m_Hits; }
    private set { m_Hits = value; }
  }

  private void Awake()
  {
    m_BrickPowerUpSpawner = GetComponent<BrickPowerUpSpawner>();
  }
  private void Start()
  {
    m_Hits = 0;

    if (IsDestructible)
      GameManager.Instance.GameManagerElements.AddBrick(this);
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ball"))
    {
      GetBall(collision.gameObject);
      ModifyBallDirection();
      Hitted();
    }
  }
  // Logic when the brick is destroyed.
  private void Hitted()
  {
    if (m_IsDestructible)
    {
      m_Hits++;

      if (m_Hits >= m_MaxHits)
      {
        if (m_BrickPowerUpSpawner != null)
          m_BrickPowerUpSpawner.SpawnPowerUp();

        GameManager.Instance.GameManagerElements.AddScore(m_Points);
        GameManager.Instance.GameManagerElements.EliminateBrick(this);
        Destroy(gameObject);
      }
    }
  }
  // Gets the Ball.
  private void GetBall(GameObject go)
  {
    if (m_Ball == null || go != m_Ball.gameObject)
      m_Ball = go.GetComponent<Ball>();
  }
  // Modifies the ball Direction.
  private void ModifyBallDirection()
  {
    if (m_Ball != null)
      m_Ball.BallMovement.SwapDirection(gameObject);
  }
}

using UnityEngine;

public class PaddleReduceVelocity : PowerUp
{
  // Reference to the paddle.
  private Paddle m_Paddle;
  // Value to reduce the paddle movement speed.
  [SerializeField] private float m_DecreaseVelocity;

  // Setters/Getters
  public float DecreaseVelocity
  {
    get { return m_DecreaseVelocity; }
    private set { m_DecreaseVelocity = value; }
  }

  protected override void Awake()
  {
    base.Awake();
  }
  protected override void Start()
  {
    base.Start();
  }
  private void OnEnable()
  {
    if (m_Timer != null)
    {
      m_Timer.StartTimer += Decrease;
      m_Timer.StartTimer += Deactivate;

      m_Timer.EndedTimer += Increase;
      m_Timer.EndedTimer += Destroy;
    }
  }
  private void OnDisable()
  {
    if (m_Timer != null)
    {
      m_Timer.StartTimer -= Decrease;
      m_Timer.StartTimer -= Deactivate;

      m_Timer.EndedTimer -= Increase;
      m_Timer.EndedTimer -= Destroy;
    }
  }
  protected override void Update()
  {
    base.Update();
  }
  protected override void OnTriggerEnter(Collider other)
  {
    base.OnTriggerEnter(other);

    if (other.gameObject.layer == LayerMask.NameToLayer("Paddle"))
    {
      GetPaddle(other.gameObject);

      if (m_Paddle != null)
        StartCountDown();
    }
  }
  // Restores the initial movement speed.
  private void Increase()
  {
    if(m_Paddle != null)
      m_Paddle.PaddleMovement.IncreaseVelocity(m_DecreaseVelocity);
  }
  // Decreases the movement speed.
  private void Decrease()
  {
    if (m_Paddle != null)
      m_Paddle.PaddleMovement.ReduceVelocity(m_DecreaseVelocity);
  }
  // Gets the paddle.
  private void GetPaddle(GameObject go)
  {
    if (m_Paddle == null || go != m_Paddle.gameObject)
      m_Paddle = go.GetComponent<Paddle>();
  }
}

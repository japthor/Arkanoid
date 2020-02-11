using UnityEngine;

public class PaddleExpand : PowerUp
{
  // Reference to the Paddle.
  private GameObject m_Paddle;
  // Value to expand the paddle.
  [SerializeField] private float m_Expand;

  // Setters/Getters
  public float Expand
  {
    get { return m_Expand; }
    private set { m_Expand = value; }
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
    if(m_Timer != null)
    {
      m_Timer.StartTimer += ExpandPaddle;
      m_Timer.StartTimer += Deactivate;

      m_Timer.EndedTimer += ShrinkPaddle;
      m_Timer.EndedTimer += Destroy;
    }
  }
  private void OnDisable()
  {
    if (m_Timer != null)
    {
      m_Timer.StartTimer -= ExpandPaddle;
      m_Timer.StartTimer -= Deactivate;

      m_Timer.EndedTimer -= ShrinkPaddle;
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
  // Expands the paddle.
  private void ExpandPaddle()
  {
    ModifyPaddle(m_Expand);
  }
  // Shrinks the paddle.
  private void ShrinkPaddle()
  {
    ModifyPaddle(-m_Expand);
  }
  // Modifies the Paddle X Scale
  private void ModifyPaddle(float value)
  {
    if (m_Paddle)
    {
      var scale = m_Paddle.transform.localScale;
      scale.x += value;
      m_Paddle.transform.localScale = scale;
    }
  }
  // Gets the paddle.
  private void GetPaddle(GameObject go)
  {
    if (m_Paddle == null || go != m_Paddle.gameObject)
      m_Paddle = go;
  }
}

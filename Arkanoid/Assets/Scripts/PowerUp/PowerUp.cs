using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PowerUpMovement), typeof(PowerUpTimer))]
public abstract class PowerUp : MonoBehaviour
{
  // Reference to PowerUpMovement
  protected PowerUpMovement m_Movement;
  // Reference to PowerUpTimer
  protected PowerUpTimer m_Timer;
  // Reference to Collider
  protected Collider m_Collider;
  // Reference to MeshRenderer
  protected MeshRenderer m_MeshRenderer;

  // Setters/Getters
  public PowerUpMovement Movement
  {
    get { return m_Movement; }
    private set { m_Movement = value; }
  }
  public PowerUpTimer Timer
  {
    get { return m_Timer; }
    private set { m_Timer = value; }
  }
  public Collider Collider
  {
    get { return m_Collider; }
    private set { m_Collider = value; }
  }
  public MeshRenderer MeshRenderer
  {
    get { return m_MeshRenderer; }
    private set { m_MeshRenderer = value; }
  }


  protected virtual void Awake()
  {
    m_Movement = GetComponent<PowerUpMovement>();
    m_Timer = GetComponent<PowerUpTimer>();

    m_Collider = GetComponent<Collider>();
    m_MeshRenderer = GetComponent<MeshRenderer>();
  }
  protected virtual void Start()
  {
    if(m_Timer != null)
     m_Timer.InitStart();
  }
  protected virtual void Update()
  {
    if (m_Movement != null)
      m_Movement.Tick();
  }
  protected virtual void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer == LayerMask.NameToLayer("Dead Zone"))
      Destroy(gameObject);
  }
  // Starts the Coroutine
  protected void StartCountDown()
  {
    if(m_Timer != null)
     StartCoroutine(m_Timer.CountDown());
  }
  // Deactivates the collider and mesherender when it collides with the paddle.
  protected void Deactivate()
  {
    if (m_Collider != null)
      m_Collider.enabled = false;

    if(m_MeshRenderer != null)
      m_MeshRenderer.enabled = false;
  }
  // Destroys the gameobject.
  protected void Destroy()
  {
    Destroy(gameObject);
  }
}

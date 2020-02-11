using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
  // Reference to the InputController.
  private InputController m_InputController;
  // Saves if the input axis is 1 or -1.
  private Vector2 m_Axis;

  // Setters/Getters
  public InputController InputController
  {
    get { return m_InputController; }
    private set { m_InputController = value; }
  }
  public Vector2 Axis
  {
    get { return m_Axis; }
    private set { m_Axis = value; }
  }

  public InputManager()
  {
    m_InputController = new InputController();
    m_InputController.Paddle.Movement.performed += ctx => m_Axis = ctx.ReadValue<Vector2>();
  }

  // OnEnable
  public void Enable()
  {
    if(m_InputController != null)
      m_InputController.Enable();
  }
  // OnDisable
  public void Disable()
  {
    if (m_InputController != null)
      m_InputController.Disable();
  }
}

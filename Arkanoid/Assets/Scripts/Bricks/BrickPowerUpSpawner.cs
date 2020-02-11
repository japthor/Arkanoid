using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrickPowerUpSpawner : MonoBehaviour
{
  // List of the power ups to spawn.
  [SerializeField] private List<PowerUp> m_PowerUps;
  // Probability to spawn a power up after it breaks.
  [Range(0.0f, 100.0f)] [SerializeField] private float m_SpawnPowerUpProbability;

  // Setters/Getters
  public List<PowerUp> PowerUps
  {
    get { return m_PowerUps; }
    private set { m_PowerUps = value; }
  }
  public float SpawnPowerUpProbability
  {
    get { return m_SpawnPowerUpProbability; }
    private set { m_SpawnPowerUpProbability = value; }
  }

  // Spwans a power up.
  public void SpawnPowerUp()
  {
    if (Spawnable())
    {
      int value = Random.Range(0, m_PowerUps.Count);
      GameObject.Instantiate(m_PowerUps[value], transform.position, Quaternion.identity);
    }
  }
  // Logic for deciding to spawn or not the power up.
  private bool Spawnable()
  {
    float value = Random.Range(0.0f, 100.0f);

    if (value <= m_SpawnPowerUpProbability)
      return true;

    return false;
  }
}

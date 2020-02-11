using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager
{
  public ScenesManager() {}
  // Loads a scene.
  public void LoadScene(int scene)
  {
    if(scene <= SceneManager.sceneCountInBuildSettings)
      SceneManager.LoadScene(scene);
  }
  // Goes to the Main Menu.
  public void LoadMainMenu()
  {
    SceneManager.LoadScene(0);
  }
  // Goes to the next scene.
  public void NextScene()
  {
    int current = SceneManager.GetActiveScene().buildIndex + 1;

    if(current <= SceneManager.sceneCountInBuildSettings)
      SceneManager.LoadScene(current);
  }
}

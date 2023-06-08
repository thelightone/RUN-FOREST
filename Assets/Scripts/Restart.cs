using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
  private void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

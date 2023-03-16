using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace.MenuScripts
{
    public class Pause : MonoBehaviour
    {
        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
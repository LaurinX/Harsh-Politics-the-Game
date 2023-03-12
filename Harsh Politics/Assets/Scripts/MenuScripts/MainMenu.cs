using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        switch (PlayerPrefs.GetInt("SelectedMap"))
        {
            case 0:
                SceneManager.LoadScene("brandenburger");
                break;
            case 1:
                SceneManager.LoadScene("eiffelturm");
                break;
            case 2:
                SceneManager.LoadScene("trumpkim");
                break;
            case 3:
                SceneManager.LoadScene("bundestag");
                break;
            case 4:
                SceneManager.LoadScene("office");
                break;
            case 5:
                SceneManager.LoadScene("scholz");
                break;
            case 6:
                SceneManager.LoadScene("palace");
                break;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

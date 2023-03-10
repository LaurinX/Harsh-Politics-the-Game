
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelection : MonoBehaviour
{
    private Sprite[] _backgroundImages;
    private Image _currentScene;
    private int _sceneNumber = 0;
    private int _maxSceneNumber;

    void Start()
    {
        _backgroundImages = Resources.LoadAll<Sprite>("background");
        _maxSceneNumber = _backgroundImages.Length;
        _currentScene = GetComponent<Image>();
        _currentScene.sprite = _backgroundImages[_sceneNumber];
    }

    public void Next()
    {
        if (_sceneNumber < _maxSceneNumber)
        {
            _sceneNumber++;
            _currentScene.sprite = _backgroundImages[_sceneNumber];
        }
        else
        {
            _sceneNumber = 0;
            _currentScene.sprite = _backgroundImages[_sceneNumber];

        }
    }

    public void Back()
    {
        if (_sceneNumber > 0)
        {
            _sceneNumber--;
            _currentScene.sprite = _backgroundImages[_sceneNumber];
        }
        else
        {
            _sceneNumber = _maxSceneNumber-1;
            _currentScene.sprite = _backgroundImages[_sceneNumber];

        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("eiffelturm", LoadSceneMode.Single);
    }
}

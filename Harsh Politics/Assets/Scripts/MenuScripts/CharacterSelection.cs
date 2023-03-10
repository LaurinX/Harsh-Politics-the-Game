using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
        
    private object[] _characters;
    private GameObject _currentPlayable;
    private int _playableNumber = 0;
    private int _maxPlayableNumber;

    private GameObject _player1;

    private GameObject _player2;

    private void Start()
    {
        _characters = Resources.LoadAll<GameObject>("Playable");
        _maxPlayableNumber = _characters.Length;
        _currentPlayable = GetComponent<GameObject>();
    }

    public void Next()
    {
        if (true)
        {
            
        }
    }

    public void Back()
    {
        
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void GoToScene()
    {
        SceneManager.LoadScene("SceneSelection", LoadSceneMode.Single);
    }
}
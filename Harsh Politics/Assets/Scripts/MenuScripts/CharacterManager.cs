using UnityEngine;
using UnityEngine.UI;
public class CharacterManager : MonoBehaviour
{
    public CharacterDb characterDB;

    public Image img;

    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCharacter(selectedOption);
        PlayerPrefs.SetInt("SelectedPlayer1", selectedOption);
        PlayerPrefs.SetInt("SelectedPlayer2", selectedOption);
        PlayerPrefs.SetInt("SelectedMap",selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }
        
        UpdateCharacter(selectedOption);
    }

    public void UpdatePlayer1Pref()
    {
        PlayerPrefs.SetInt("SelectedPlayer1", selectedOption);
    }

    public void UpdatePlayer2Pref()
    {
        PlayerPrefs.SetInt("SelectedPlayer2", selectedOption);
    }

    public void UpdateMapPref()
    {
        PlayerPrefs.SetInt("SelectedMap",selectedOption);
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        img.sprite = character.characterSprite;
    }
}

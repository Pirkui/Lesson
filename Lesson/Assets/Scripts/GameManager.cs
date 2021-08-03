using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Saving;
public class GameManager : MonoBehaviour
{

    [SerializeField] TMP_InputField inputField;

    bool thisIsAnotherBooleanValue = false;
    bool testing = true;
    float thisIsAnotherTestValue = 6f;

    public string playerName;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SaveManager.Instance.Load();
        inputField.text = SaveManager.Instance.state.playerName;
    }


    public void OnTextSelected()
    {
        if (inputField.text == inputField.placeholder.gameObject.GetComponent<TextMeshProUGUI>().text)
        {
            inputField.text = "";
        }

    }


    public void OntextChanged()
    {
        playerName = inputField.text;
        SaveManager.Instance.state.playerName = playerName;
    }

    public void OnButtonClick()
    {
        SaveManager.Instance.Save();
        SceneManager.LoadScene("Level 1");
        
    }
}

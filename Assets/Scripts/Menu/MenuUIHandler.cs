using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor; 
#endif


public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputName;
    public TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateScore()
    {
        bestScoreText.SetText("Best Score: " + MenuManager.Instance.inputName + " : ");
    }

    public void StartGame()
    {
        MenuManager.Instance.inputName = inputName.text; 
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Aplication.Quit();
#endif
    }
}

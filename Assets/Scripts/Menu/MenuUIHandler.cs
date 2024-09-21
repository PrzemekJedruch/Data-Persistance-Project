using System.Collections;
using System.Collections.Generic;
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
    public GameObject titleScoreObject;

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
        titleScoreObject.gameObject.SetActive(true);
        bestScoreText.SetText("Best Score: " + MenuManager.Instance.bestScoreName + " : " + MenuManager.Instance.bestScore);
    }

    public void StartGame()
    {
        MenuManager.Instance.tmpName = inputName.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MenuManager.Instance.SavePlayer();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Aplication.Quit();
#endif
    }
}

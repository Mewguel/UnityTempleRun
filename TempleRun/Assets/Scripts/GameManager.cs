using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager GameInstance;
    public GameObject GameOverPanel;


    private void Awake()
    { 
        GameInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

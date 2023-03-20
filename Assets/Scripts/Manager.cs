using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    public GameObject[] puzzleCubes;
    public GameObject winPopUp;

    private void Start()
    {
        puzzleCubes = GameObject.FindGameObjectsWithTag("Cube");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApplication();
        }

        if(IsAllPuzzleCubesCorrect())
        {
            Debug.Log("Win");
            winPopUp.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private bool IsAllPuzzleCubesCorrect()
    {
        for (int i = 0; i < puzzleCubes.Length; ++i)
        {
            if (puzzleCubes[i].GetComponent<CubeInteract>().correctCube == false)
            {
                return false;
            }
        }

        return true;
    }

    public void QuitApplication()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }

    public void RestartLevel()
    {
        Debug.Log("Restarting..");
        SceneManager.LoadScene(0);
    }
}

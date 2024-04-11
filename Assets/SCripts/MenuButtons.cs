using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
  [SerializeField] private  int ButtonIndex = 0;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if(ButtonIndex == 0) {

                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }
            else if (ButtonIndex == 1)
            {

                SceneManager.LoadScene(2, LoadSceneMode.Single);
            }
            else if(ButtonIndex == 2) {
                PlayerPrefs.SetFloat("X", 0);
                PlayerPrefs.SetFloat("Y", 0);
                Application.Quit();

            }
            else if (ButtonIndex == 3)
            {

                SceneManager.LoadScene(0, LoadSceneMode.Single);

            }

        }
    }
}

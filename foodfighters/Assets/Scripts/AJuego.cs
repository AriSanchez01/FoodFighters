using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AJuego : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        //if press any key jump to gameplay scene
        if (Input.GetKeyDown(KeyCode.Return))
        {
            new WaitForSeconds(5);
            Invoke("LoadScene", 0.5f);
        }

    }

    void LoadScene()
    {
        //load gameplay scene
        SceneManager.LoadScene("Game");
    }

}

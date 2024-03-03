using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Splash : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Invoke("loadscene", 2f);   
        
    }

    private void loadscene()
    {
        SceneManager.LoadScene("app");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    private void Update()
    {
        ActiveEndPoint();
    }
    void ActiveEndPoint()
    {
        if(Time.time > 300)
        {
            SceneManager.LoadScene(0);
        }
    }
}

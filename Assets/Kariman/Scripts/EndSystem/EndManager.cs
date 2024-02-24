using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    private void Start()
    {
       StartCoroutine(ActiveEndPoint());
    }
    IEnumerator ActiveEndPoint()
    {
        yield return new WaitForSeconds(300f);
        SceneManager.LoadScene(4);
    }
}

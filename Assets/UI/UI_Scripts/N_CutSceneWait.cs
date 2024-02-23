using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class N_CutSceneWait : MonoBehaviour
{
    public float waitTime = 35f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startIntro());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            waitTime = 0;
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator startIntro()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }
}

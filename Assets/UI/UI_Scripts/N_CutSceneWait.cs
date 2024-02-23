using System.Collections;
using System.Collections.Generic;
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

    IEnumerator startIntro()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }
}

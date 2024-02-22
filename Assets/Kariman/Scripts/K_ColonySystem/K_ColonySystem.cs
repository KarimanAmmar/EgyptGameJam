using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class K_ColonySystem : MonoBehaviour
{
    [SerializeField] List<Image> RewardEggs;
    [SerializeField] GameEvents eggEvent;

    int counter=-1;

    int SolidColorValue = 255;
    int FaddedColorValue = 45;

    private void OnEnable()
    {
        eggEvent.GameAction += ONINcreaceCounter;
    }
    private void OnDisable()
    {
        eggEvent.GameAction -= ONINcreaceCounter;
    }
    void SoldEggScore()
    {
        if (counter <= 5)
        {
            Color tmp = RewardEggs[counter].GetComponent<Image>().color;
            tmp.a = 0;
            RewardEggs[counter].GetComponent<Image>().color = tmp;
            StartCoroutine(FadeEggScore());
        }
    }
    IEnumerator FadeEggScore()
    {
        yield return new WaitForSeconds(5);
        Color col = RewardEggs[counter].GetComponent<Image>().color;
        col.a = FaddedColorValue;
        Debug.Log(col);
        RewardEggs[counter].GetComponent<Image>().color = col;
        //RewardEggs[counter].GetComponent<Image>().color = col;
        Debug.Log(RewardEggs[counter].GetComponent<Image>().color);
        if(counter >= 0)
        {
            counter--;
        }
        Debug.Log("Counter"+counter);
    }
    void ONINcreaceCounter()
    {
        counter++;
        SoldEggScore();
        Debug.Log(counter);
    }
}

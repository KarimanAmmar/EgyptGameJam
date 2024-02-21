using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class K_ColonySystem : MonoBehaviour
{
    [SerializeField] List<Image> RewardEggs;

    int counter=-1;

    int SolidColorValue = 255;
    int FaddedColorValue = 45;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            counter++;
            Debug.Log(counter);
            if (counter <= RewardEggs.Count)
            {
                SoldEggScore();
                FadeEggScore();
            }
        }
    }
    void SoldEggScore()
    {
        Color tmp = RewardEggs[counter].GetComponent<Image>().color;
        tmp.a = SolidColorValue;
        RewardEggs[counter].GetComponent<Image>().color = tmp;
    }   
    void FadeEggScore()
    {
       
    }
}

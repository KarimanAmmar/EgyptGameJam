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

    [SerializeField] HordeController MainPigController;
    [SerializeField] GameObject pigeonPrefab;
    [SerializeField] Sprite soledEgg;
    [SerializeField] Sprite Faddedegg;
    [SerializeField] PigeonFlock pigeonFlock;
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
            RewardEggs[counter].GetComponent<Image>().sprite = soledEgg;
            StartCoroutine(FadeEggScore());
        }
    }
    IEnumerator FadeEggScore()
    {
        yield return new WaitForSeconds(7);
        RewardEggs[counter].GetComponent<Image>().sprite = Faddedegg;
        AddPigeon();
        if (counter >= 0)
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
    void AddPigeon()
    {
        GameObject InstantiatedPigeon = Instantiate(pigeonPrefab, 
            new Vector3(MainPigController.Center.x, MainPigController.Center.y, 0), Quaternion.identity);

        pigeonFlock._pAgentsList.Add(InstantiatedPigeon.GetComponent<PigeonFlockAgent>());
    }
}

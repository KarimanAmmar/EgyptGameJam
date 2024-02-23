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
    [SerializeField] GameEvents InstantiateEvent;

    public int counter=-1; 

    [SerializeField] HordeController MainPigController;
    [SerializeField] GameObject pigeonPrefab;
    [SerializeField] Sprite soledEgg;
    [SerializeField] Sprite Faddedegg;
    [SerializeField] PigeonFlock pigeonFlock;
    private void OnEnable()
    {
        eggEvent.GameAction += ONINcreaceCounter;
        InstantiateEvent.GameAction += AddPigeon;
    }
    private void OnDisable()
    {
        eggEvent.GameAction -= ONINcreaceCounter;
        InstantiateEvent.GameAction -= AddPigeon;
    }
    void SoldEggScore()
    {
        if (counter <5)
        {
            RewardEggs[counter].sprite = soledEgg;
            StartCoroutine(FadeEggScore());
        }
    }
    IEnumerator FadeEggScore()
    {
        yield return new WaitForSeconds(20);
        RewardEggs[counter].sprite = Faddedegg;
        AddPigeon();
        if (counter >= 0)
        {
            counter--;
        }
        Debug.Log("Counter "+counter);
    }
    void ONINcreaceCounter()
    {
        if (counter < 4)
        {
            counter++;
            SoldEggScore();
        }
        Debug.Log("counter" +counter);
    }
    void AddPigeon()
    {
       PigeonFlockAgent newPigeon = Instantiate(pigeonFlock._pAgentPrefab, (UnityEngine.Random.insideUnitCircle * pigeonFlock._pAgentsList.Count * 0.08f) + HordeController.instance.Center,
            Quaternion.Euler(Vector3.forward * UnityEngine.Random.Range(0f, 360f)),
            pigeonFlock.gameObject.transform);

        pigeonFlock._pAgentsList.Add(newPigeon);
        Debug.Log("pigeon added");
    }
}

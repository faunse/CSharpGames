using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class SpawnerScript : MonoBehaviour
{
    public float amountOfEnemies = 6f;
    public float RoundsOfEnemies = 1f;
    public int currentRound = 1;
    public int aliveEnemies;
    public int DeadEnemies;
    bool Finished;
    public Transform[] Spawners;
    public int SbetweenRounds = 10;
    public bool IsShopAccesible;
    private InputAction m_OpenShop;
    public GameObject m_store;
    public GameObject Enemy;


    public void CountTheDead(int Dead)
    {
        DeadEnemies = Dead + DeadEnemies;
        CheckRoundStatus();
    }

    public void CheckRoundStatus()
    {
        if (DeadEnemies == aliveEnemies && Finished == true)
        {
            StartCoroutine("FinishRound");
            Debug.Log("ROUND FINISHED");

        }
    }

    public IEnumerator StartRound()
    {
        aliveEnemies = 0;
        DeadEnemies = 0;
        IsShopAccesible = false;

        for (float i = 0; i < RoundsOfEnemies; i++)
        {
            for (float j = 0; j < amountOfEnemies; j++)
            {
                var randomSpawnPoints = Spawners[Random.Range(0, Spawners.Length)];
                Instantiate(Enemy, randomSpawnPoints.position, Quaternion.identity);
                aliveEnemies++;
               
                
            }
            yield return new WaitForSeconds(SbetweenRounds);
        }

        Finished = true;
    }

    public IEnumerator FinishRound()
    {
        IsShopAccesible = true;



        yield return new WaitForSeconds(20);

    }

    public void Start()
    {
        StartCoroutine("StartRound");
        
        m_OpenShop = InputSystem.actions.FindAction("OpenShop");
    }



    private void Update()
    {
        if (m_OpenShop.WasPressedThisFrame() && IsShopAccesible == true)
        {
            if (m_store.active == true)
            {
                Debug.Log("CLOSE");
                m_store.SetActive(false);

            }
            else
            {
                Debug.Log("OPEN");
                m_store.SetActive(true);
            }
            
            

        }
    }
}





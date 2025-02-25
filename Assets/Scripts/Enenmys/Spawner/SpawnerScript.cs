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
    public float SbetweenRounds = 10;
    public bool IsShopAccesible;
    private InputAction m_OpenShop;
    public GameObject m_store;
    public GameObject Enemy;
    public int flow = 0;
    private int m_EnemyHealth;
    private int m_EnemyDamage;
    public GameObject TimerOBJ;

    // counts how many enemies are dead 
    public void CountTheDead(int Dead)
    {
        DeadEnemies = Dead + DeadEnemies;
        CheckRoundStatus();
    }
    // then checks if all enemies are dead
    public void CheckRoundStatus()
    {
        
        if (DeadEnemies == aliveEnemies && Finished == true)
        {
            if (flow != 0)
            {
                flow = 0;
                Debug.Log("Finish");
                StartCoroutine("FinishRound");
            }                    
        }
    }
    public IEnumerator StartRound()
    {
        aliveEnemies = 0;
        IsShopAccesible = false;
        DeadEnemies = 0;
        flow = 1;
        Finished = false;

        // Spawns amount of waves of enemies at random spawn locations
        for (float a = 0f; RoundsOfEnemies > a; a++) 
        {
            Debug.Log(a);
            for (float j = 0; j < amountOfEnemies; j++)
            {
                var randomSpawnPoints = Spawners[Random.Range(0, Spawners.Length)];
                Instantiate(Enemy, randomSpawnPoints.position, Quaternion.identity);
                Enemy.GetComponent<Enemycontroller>().AddDificulty(m_EnemyHealth, m_EnemyDamage);
                aliveEnemies++;
             
            }           
            Debug.Log($"Rounds " + RoundsOfEnemies);
            yield return new WaitForSeconds(SbetweenRounds);
        }

        Finished = true;
    }

    public IEnumerator FinishRound()
    {

        IsShopAccesible = true;
        TimerOBJ.SetActive(true);
        PreStart();
        yield return new WaitForSeconds(10);
        StartCoroutine("StartRound");

    }

    public void Start()
    {
        StartCoroutine("StartRound");
        
        m_OpenShop = InputSystem.actions.FindAction("OpenShop");
    }
    private void Update()
    {
        // checks if shop can be accessed
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

    private void PreStart()
    {
        // upadtes enemy stats to make them stronger over time also increases waves of enemies
        currentRound++;
        if (currentRound % 3 == 0)
        {

            RoundsOfEnemies++;
            m_EnemyDamage += 5;
            m_EnemyHealth += 5;
            
        }
        if (currentRound % 2 == 0)
        {
            amountOfEnemies *= 1.35f;
            Mathf.FloorToInt(amountOfEnemies);
        }

        if (currentRound % 4 == 0)
        {
            SbetweenRounds -= 0.5f;
        }
    }    
}





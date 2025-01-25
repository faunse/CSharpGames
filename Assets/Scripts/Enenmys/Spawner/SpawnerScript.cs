using UnityEngine;
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

    public void StartRound()
    {
        for (float i = 0; i < RoundsOfEnemies; i++)
        {
            for (float j = 0; j < amountOfEnemies; j++)
            {
                var randomSpawnPoints = Spawners[Random.Range(0, Spawners.Length)];
                
                

            }
             
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] groundPrefs;
    private List<GameObject> activeGround = new List<GameObject>();
    [SerializeField] private float spawnPos = 0;
    [SerializeField] private float groundLength = 20;
    [SerializeField] private Transform player;
    [SerializeField] private int startGround = 5;

    void Start()
    {
        for(int i = 0; i < startGround; i++)
        {
            SpawnGround(Random.Range(0, groundPrefs.Length));
        }
    }
    void Update()
    {
        if(player.position.z - 20 > spawnPos - (startGround * groundLength))
        {
            SpawnGround(Random.Range(0, groundPrefs.Length));
            DeleteGround();
        }
    }
    private void SpawnGround(int groundIndex)
    {
        GameObject nextGround = Instantiate(groundPrefs[groundIndex], transform.forward * spawnPos, transform.rotation);
        activeGround.Add(nextGround);
        spawnPos += groundLength;
    }
    private void DeleteGround()
    {
        Destroy(activeGround[0]);
        activeGround.RemoveAt(0);
    }

}


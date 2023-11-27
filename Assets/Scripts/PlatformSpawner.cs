using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _platform;
    [SerializeField]
    private GameObject _diamond;
    private Vector3 _latestPos;
    private float _size;

    void Start()
    {
        _latestPos = _platform.transform.position;
        _size = _platform.transform.localScale.x;
        for (int i = 0; i < 21; i++)
        {
            SpawnRandomly();
        }
    }

    void Update()
    {
        if (GameObject.Find("Ball").GetComponent<BallController>().GameOver) CancelInvoke("SpawnRandomly");
    }

    void SpawnRandomly()
    {
        int randomizer = Random.Range(0, 6);
        if (randomizer < 3) SpawnX();
        else if (randomizer >= 3) SpawnZ();
    }

    void SpawnX()
    {
        Vector3 spawnPosition = _latestPos;
        spawnPosition.x += _size;
        _latestPos = spawnPosition;
        Instantiate(_platform, spawnPosition, Quaternion.identity);
        
        int randomizer = Random.Range(0, 4);
        if (randomizer < 1) Instantiate(_diamond, new Vector3(spawnPosition.x, spawnPosition.y + 1f, spawnPosition.z), _diamond.transform.rotation);
    }

    void SpawnZ()
    {
        Vector3 spawnPosition = _latestPos;
        spawnPosition.z += _size;
        _latestPos = spawnPosition;
        Instantiate(_platform, spawnPosition, Quaternion.identity);
        
        int randomizer = Random.Range(0, 4);
        if (randomizer < 1) Instantiate(_diamond, new Vector3(spawnPosition.x,spawnPosition.y + 1f,spawnPosition.z), _diamond.transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Ball") InvokeRepeating("SpawnRandomly", 0, 0.25f);
    }
}

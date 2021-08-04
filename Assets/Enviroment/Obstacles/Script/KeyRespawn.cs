using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyRespawn : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;

    [SerializeField] GameObject KeyModel;
    [SerializeField] GameObject KeyUI;

    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_RESPAWN, RespawnKeys);

        foreach (GameObject spawnpoint in spawnPoints)
        {
            spawnpoint.SetActive(false);
        }

        int i = Random.Range(0, 4);
        GameObject Key = GameObject.Instantiate(KeyModel, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation, null);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void RespawnKeys()
    {
        if (KeyUI.GetComponent<Image>().color == Color.yellow)
        {
            int i = Random.Range(0, 4);
            GameObject Key = GameObject.Instantiate(KeyModel, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation, null);
        }
    }
}

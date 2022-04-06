using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TankAIBenchmark : MonoBehaviour
{
    [SerializeField]
    private UpdateChanger updateChanger;
    Transform[] tanks;
    public int numberOfTanks;
    public GameObject tankPrefab;
    //[SerializeField] private GameObject player;
    private Vector3 vec = new Vector3(0, 0, 0.05f);
    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        tanks = new Transform[numberOfTanks];
        updateChanger.Instance(numberOfTanks);
        for (int i = 0; i < numberOfTanks; i++)
        {
            tanks[i] = Instantiate(tankPrefab.transform);
            tanks[i].transform.position = new Vector3(Random.Range(-50,50), 0, Random.Range(-50,50));
            updateChanger.Add(tanks[i].gameObject.GetComponent<SoloAi>());
        }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (playerTransform == null)
    //     {
    //         return;
    //     }
    //     foreach (var t in tanks)
    //     {
    //         t.LookAt(playerTransform);
    //         t.Translate(0, 0, 0.05f);
    //     } 
    // }
}

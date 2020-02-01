using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    enum TypeSpawn { Random,List}

    [SerializeField]
    public bool activ = false;
    [SerializeField]
    public List<GameObject> prefabs;

    [SerializeField]
    public float range = 0;
    [SerializeField]
    public int numberMob = 0;
    [SerializeField]
    public float coolDown = 0;

    [SerializeField]
    public List<List<GameObject>> waveMobs;
    [SerializeField]
    TypeSpawn type;

    float timer = 0;
    int numberWave = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activ)
        {
            if (timer <= 0)
            {
                if (type == TypeSpawn.Random)
                {
                    SpawnMob(numberMob);
                }
                else
                {
                    if (numberWave < waveMobs.Count)
                    {
                        SpawnMob(numberMob);
                    }
                }
                timer = coolDown;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        
    }

    public void SpawnMob(List<GameObject> mobs)
    {
        foreach (GameObject mob in mobs)
        {
            GameObject obj = Instantiate(mob) as GameObject;
            obj.transform.position = new Vector3(Random.Range(0, range), Random.Range(0, range),0);
        }
    }

    public void SpawnMob(int number)
    {
        List<GameObject> mobs = new List<GameObject>();
        for (int i = 0; i < number; i++)
        {
            mobs.Add(prefabs[Random.Range(0, prefabs.Count)]);
        }
        SpawnMob(mobs);
    }

    public void RestartWave()
    {
        numberWave = 0;
    }

    public void SetStatsMob()
    {

    }
}

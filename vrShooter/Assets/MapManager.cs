using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class MapManager : MonoBehaviour
{
    public int activeMapNum = 3;
    public GameObject[] maps;
    private Random r = new Random();
    private List<GameObject> activeMaps;

    void Start()
    {
        activeMaps = new List<GameObject>();
        loadNext(new Vector3(0, 0, 0));
    }

    public void loadNext(Vector3 pos)
    {
        int index = r.Next(0, maps.Length);
        activeMaps.Add(Instantiate(maps[index], pos, Quaternion.identity));

        if (activeMaps.Count > activeMapNum)
        {
            Destroy(activeMaps.First());
            activeMaps.RemoveAt(0);
        }
    }
}
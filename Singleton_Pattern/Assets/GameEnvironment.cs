using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnvironment
{
    private static GameEnvironment instance;
    private List<GameObject> obstacles = new List<GameObject>();
    private List<GameObject> goalsList = new List<GameObject>();

    public List<GameObject> Obstacles
    {
        get { return obstacles; }
    }
    public List<GameObject> GoaList
    {
        get { return goalsList; }
    }

    public static GameEnvironment Singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new GameEnvironment();
                instance.GoaList.AddRange(GameObject.FindGameObjectsWithTag("goal"));
            }

            return instance;
        }
    }

    public void AddObstacles(GameObject go)
    {
        obstacles.Add(go);
    }

    public void RemoveObstacles(GameObject go)
    {
        int index = obstacles.IndexOf(go);
        obstacles.RemoveAt(index);
        GameObject.Destroy(go);
    }

    public GameObject RandomGoal()
    {
        return goalsList[Random.Range(0, goalsList.Count)];
    }
}

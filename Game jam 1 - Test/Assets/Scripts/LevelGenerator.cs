using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;
    //Fuck you seun this is my code, why are you looking at it, you doubting me?
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Player player;

    public Vector3 lastEndPosition;

    // Start is called before the first frame update
    void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        int startingSpawnLevelParts = 5;
        for (int i = 8; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART) { // spawn another level part
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {
        Transform chosenlevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenlevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        levelPartTransform.transform.parent = transform;
        return levelPartTransform;
    }
    public Vector3 GetPosition() { return transform.position; }
}

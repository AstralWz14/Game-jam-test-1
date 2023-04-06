using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionDeleter : MonoBehaviour
{
    Player player;
    LevelGenerator LG;
    public float timer = 50f;
    public bool destroyActive;
    public bool destroyActivation2;

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 50f;
    private void Start()
    {
        LG = GameObject.FindGameObjectWithTag("LG").GetComponent<LevelGenerator>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }



    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            destroyActive = true;
            if (destroyActivation2)
            {

                timer = 50f;
                destroyActivation2 = false;
            }

        }
        else
        {
            destroyActive = false;
        }
        if (Vector3.Distance(player.GetPosition(), LG.lastEndPosition) > PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            destroyActivation2 = true;
            if (destroyActive)
            {
                Destroy(gameObject);

            }
        }
    }
}

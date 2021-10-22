using System;
using UnityEngine;

namespace mdb.memesteroid
{
    public class PlaygroundSpawner : MonoBehaviour
    {
        [Serializable]
        public struct SpawnOptions
        {
            public GameObject prefab;
            public Vector2 position;
            public Vector2 movement;
            public Vector2 scale;
            public float speed;
            public int breakTimes;
        }

        public SpawnOptions[] spawns;
        
        public void Spawn()
		{
            for (int i = 0; i < spawns.Length; i++)
            {
                Transform clone = Instantiate(spawns[i].prefab.transform, spawns[i].position, Quaternion.identity);
                clone.name = spawns[i].prefab.name;
                clone.localScale = spawns[i].scale;

                MemeEnemy memeEnemy = clone.GetComponent<MemeEnemy>();
                memeEnemy.SetMovement(spawns[i].movement);
                memeEnemy.SetBreakTimes(spawns[i].breakTimes);
                memeEnemy.SetSpeed(spawns[i].speed);
            }
		}
    }
}

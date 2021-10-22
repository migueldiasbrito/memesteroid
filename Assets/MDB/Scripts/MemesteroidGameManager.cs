using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace mdb.memesteroid
{
    public class MemesteroidGameManager : MonoBehaviour
    {
        public static MemesteroidGameManager instance = null;

        public Text livesText;
        public bool IsPlayground = false;
        public int TimeToPlay = 0;
        public PlaygroundSpawner ps;

        private List<GameObject> protectables;
        private List<GameObject> enemies;
        private Health playerHealth;
        private float timeToPlay;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                enemies = new List<GameObject>();
                protectables = new List<GameObject>();
                timeToPlay = TimeToPlay;
            }
            else
            {
                DestroyImmediate(this);
            }
        }

		private void Start()
		{
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        }

		public void RegisterEnemy(GameObject enemy)
		{
            if (!enemies.Contains(enemy))
            {
                enemies.Add(enemy);
            }
		}

        public void EnemyDestroyed(GameObject enemy)
		{
            GameManager.AddScore(10);
            enemies.Remove(enemy);

            if (enemies.Count == 0)
			{
                if (IsPlayground && ps != null)
                {
                    ps.Spawn();
                }
                else
                {
                    LevelCleared();
                }
            }
        }

        public void RegisterProtectable(GameObject protectable)
		{
            if (!protectables.Contains(protectable))
            {
                protectables.Add(protectable);
            }
        }

        public void ProtectableDestroyed(GameObject protectable)
		{
            GameOver();
		}

        public void LevelCleared()
		{
            GameManager.instance.LevelCleared();
		}

        public void GameOver()
		{
            playerHealth.gameObject.SetActive(false);
            GameManager.instance.GameOver();
            if (livesText != null)
            {
                livesText.text = "Lives: 0";
            }
        }

        public void UpdateLives()
		{
            if (livesText != null)
			{
                livesText.text = "Lives: " + playerHealth.currentLives;
			}
		}

		private void Update()
		{
			if (IsPlayground)
			{
                timeToPlay -= Time.deltaTime;

                if(timeToPlay <= 0)
				{
                    LevelCleared();
				}
                else
				{
                    livesText.text = "Time: " + Mathf.CeilToInt(timeToPlay);
				}
			}
		}
	}
}

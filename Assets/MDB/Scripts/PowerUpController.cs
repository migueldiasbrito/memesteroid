using mdb.memesteroid.input;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace mdb.memesteroid
{
    public class PowerUpController : MonoBehaviour
    {
        [Serializable]
        public struct PowerUp
		{
            public GameObject projectilePrefab;
            public float fireRate;
            public bool enabled;
            public int killsToUnlock;
        }

        public Text text;
        public PowerUp[] powerUps;

        private PowerUpInput input;
        private ShootingController shootingController;
        private int nextPowerUpToUnlock = -1;
        private int killsToUnlockNextLevel = 0;

        private void Awake()
        {
            input = new PowerUpInput();
            input.PowerUp.PowerUp1.performed += context => SelectPowerUp(0);
            input.PowerUp.PowerUp2.performed += context => SelectPowerUp(1);
            input.PowerUp.PowerUp3.performed += context => SelectPowerUp(2);
            input.PowerUp.PowerUp4.performed += context => SelectPowerUp(3);

            shootingController = GetComponent<ShootingController>();
            SelectPowerUp(0);

            for (int i = 0; i < powerUps.Length; i++)
			{
                if (powerUps[i].enabled) { continue; }
                nextPowerUpToUnlock = i;
                killsToUnlockNextLevel = powerUps[i].killsToUnlock;
                break;
			}
        }

        private void SelectPowerUp(int powerUp)
		{
            if(shootingController != null && powerUps.Length >= powerUp && powerUps[powerUp].enabled)
			{
                shootingController.projectilePrefab = powerUps[powerUp].projectilePrefab;
                shootingController.fireRate = powerUps[powerUp].fireRate;

                if (text != null)
				{
                    text.text = "Weapon: " + (powerUp + 1);
				}
            }
		}

		private void OnEnable()
		{
            input.Enable();
		}

        private void OnDisable()
        {
            input.Disable();
        }

		public void EnemyKilled()
		{
			if (nextPowerUpToUnlock >= 0)
			{
                killsToUnlockNextLevel--;
                if(killsToUnlockNextLevel <= 0)
				{
                    powerUps[nextPowerUpToUnlock].enabled = true;
                    SelectPowerUp(nextPowerUpToUnlock);
                    
                    nextPowerUpToUnlock++;
                    if (nextPowerUpToUnlock >= powerUps.Length)
                    {
                        nextPowerUpToUnlock = -1;
                    }
                    else
                    {
                        killsToUnlockNextLevel = powerUps[nextPowerUpToUnlock].killsToUnlock;
                    }
				}
			}
		}
	}
}

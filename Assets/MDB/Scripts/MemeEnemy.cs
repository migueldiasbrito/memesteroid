using System;
using UnityEngine;

namespace mdb.memesteroid
{
    public class MemeEnemy : MonoBehaviour
    {
        public GameObject hitEffect;
        public GameObject clonePrefab;

        [SerializeField] private float speed = 0;
        [SerializeField] private Vector3 movement = Vector3.zero;
        [SerializeField] private float rotation = 0;
        [SerializeField] private int breakTimes = 0;
        [SerializeField] private float invincibleTime = 0;

        private PowerUpController powerUpController;

        public void Start()
		{
            MemesteroidGameManager.instance.RegisterEnemy(this.gameObject);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) {
                powerUpController = player.GetComponent<PowerUpController>();
            }
        }

		public void ProcessHit(Vector2 colliderDirection, bool allowClones)
		{
            if(invincibleTime > 0) { return; }

            if (allowClones && breakTimes > 0)
            {
                Vector2[] clonesDirection =
                {
                    Quaternion.AngleAxis(30, Vector3.forward) * colliderDirection,
                    Quaternion.AngleAxis(-30, Vector3.forward) * colliderDirection
                };

                for (int i = 0; i < 2; i++)
                {
                    Transform clone = Instantiate(clonePrefab.transform, transform.position, Quaternion.identity);
                    clone.name = this.name;
                    clone.localScale = clone.localScale * 0.75f;

                    MemeEnemy memeEnemy = clone.GetComponent<MemeEnemy>();
                    memeEnemy.transform.position = transform.position;
                    memeEnemy.movement = clonesDirection[i % 2];
                    memeEnemy.breakTimes = breakTimes - 1;
                    memeEnemy.speed = speed * 2;
                    memeEnemy.invincibleTime = 0.5f;

                    MemesteroidGameManager.instance.RegisterEnemy(memeEnemy.gameObject);
                }
            }

            if (hitEffect != null)
            {
                Instantiate(hitEffect, transform.position, transform.rotation, null);
            }
            MemesteroidGameManager.instance.EnemyDestroyed(this.gameObject);
            if (powerUpController != null) {
                powerUpController.EnemyKilled();
            }
            Destroy(gameObject);
        }

		internal void SetSpeed(float speed)
		{
            this.speed = speed;
		}

		internal void SetBreakTimes(int breakTimes)
		{
            this.breakTimes = breakTimes;
		}

		internal void SetMovement(Vector2 movement)
		{
            this.movement = movement;
		}

		private void Update()
		{
            if (invincibleTime > 0)
			{
                invincibleTime -= Time.deltaTime;
			}

            Vector3 deltaMovement = movement * speed * Time.deltaTime;
            transform.position += deltaMovement;

            transform.Rotate(0, 0, rotation * Time.deltaTime);
        }

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.tag == "Environment")
			{
                ContactPoint2D contactPoint = collision.GetContact(0);
                float diffX = transform.position.x - contactPoint.point.x;
                float diffY = transform.position.y - contactPoint.point.y;
                
                if (Mathf.Abs(diffX) == Mathf.Abs(diffY)) {
                    movement = new Vector3(-movement.x, -movement.y);
				}
                else if (Mathf.Abs(diffX) > Mathf.Abs(diffY))
				{
                    if (movement.x > 0 && diffX < 0 || movement.x < 0 && diffX > 0)
                    {
                        movement = new Vector3(-movement.x, movement.y);
                    }
                    else
					{
                        //probably it's colling with more thant one object
					}
                }
                else
				{
                    if (movement.y > 0 && diffY < 0 || movement.y < 0 && diffY > 0)
                    {
                        movement = new Vector3(movement.x, -movement.y);
                    }
                    else
                    {
                        //probably it's colling with more thant one object
                    }
                }
			}
            else if (collision.gameObject.tag == "Player")
			{
                Health health = collision.gameObject.GetComponent<Health>();
                HandlePalyerCollision(health);
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
		{
            if (collision.gameObject.tag == "Player")
            {
                Health health = collision.gameObject.GetComponent<Health>();
                HandlePalyerCollision(health);
            }
        }

        private void HandlePalyerCollision(Health playerHealth)
		{
            if (playerHealth.currentLives > 1)
            {
                playerHealth.TakeDamage(1);
                MemesteroidGameManager.instance.UpdateLives();
            }
            else if (playerHealth.invincibilityTime > 0)
            {
                MemesteroidGameManager.instance.GameOver();
            }
        }
	}
}

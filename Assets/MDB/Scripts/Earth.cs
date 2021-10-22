using UnityEngine;

namespace mdb.memesteroid
{
    public class Earth : MonoBehaviour
    {
        public GameObject hitEffect;

        private void Start()
		{
            MemesteroidGameManager.instance.RegisterProtectable(this.gameObject);
        }

		private void OnTriggerEnter2D(Collider2D collision)
        {
            MemeEnemy memeEnemy = collision.gameObject.GetComponent<MemeEnemy>();

            if (memeEnemy != null)
            {
                if (hitEffect != null)
                {
                    Instantiate(hitEffect, transform.position, transform.rotation, null);
                }
                Destroy(this.gameObject);
                MemesteroidGameManager.instance.ProtectableDestroyed(this.gameObject);
            }
        }
    }
}

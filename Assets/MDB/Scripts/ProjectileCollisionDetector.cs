using UnityEngine;

namespace mdb.memesteroid
{
    public class ProjectileCollisionDetector : MonoBehaviour
    {
        public bool allowClones = true;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            MemeEnemy memeEnemy = collision.gameObject.GetComponent<MemeEnemy>();

            if (memeEnemy != null)
            {
                memeEnemy.ProcessHit(transform.up, allowClones);
                Destroy(this.gameObject);
            }
        }
    }
}
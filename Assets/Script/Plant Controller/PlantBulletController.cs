using UnityEngine;

namespace Script.Plant_Controller
{
    public class PlantBulletController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Monster"))
            {
                Destroy(gameObject);
            }
        }
    }
}

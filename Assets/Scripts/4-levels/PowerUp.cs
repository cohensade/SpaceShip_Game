using UnityEngine;

/**
 * This component represents a Power-Up that upgrades the player's laser.
 */
public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // בדוק אם ה-Power-Up נוגע בשחקן
        if (other.CompareTag("Player"))
        {
            Debug.Log("Power-Up collected! Laser upgraded.");

            // גש לסקריפט שמנהל את הלייזר ושדרג אותו
            LaserShooter laserShooter = other.GetComponent<LaserShooter>();
            if (laserShooter != null)
            {
                laserShooter.UpgradeLaser(); // שדרוג הלייזר
            }

            // השמד את ה-Power-Up לאחר האיסוף
            Destroy(this.gameObject);
        }
    }
}

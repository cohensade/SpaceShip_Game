using UnityEngine;

/**
 * This component represents a Power-Up that upgrades the player's laser.
 */
public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���� �� �-Power-Up ���� �����
        if (other.CompareTag("Player"))
        {
            Debug.Log("Power-Up collected! Laser upgraded.");

            // �� ������� ����� �� ������ ����� ����
            LaserShooter laserShooter = other.GetComponent<LaserShooter>();
            if (laserShooter != null)
            {
                laserShooter.UpgradeLaser(); // ����� ������
            }

            // ���� �� �-Power-Up ���� ������
            Destroy(this.gameObject);
        }
    }
}

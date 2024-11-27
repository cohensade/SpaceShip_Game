using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    private int laserLevel = 1; // ��� ������ ��������

    public void UpgradeLaser()
    {
        laserLevel++; // ����� ��� ������
        Debug.Log("Laser upgraded to level: " + laserLevel);
    }

    public void Shoot()
    {
        if (laserLevel == 1)
        {
            // ��� ����
            Debug.Log("Shooting normal laser");
        }
        else if (laserLevel == 2)
        {
            // ��� ���� �� ��� ����
            Debug.Log("Shooting upgraded laser!");
        }
    }
}

using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    private int laserLevel = 1; // רמת הלייזר ההתחלתית

    public void UpgradeLaser()
    {
        laserLevel++; // שדרוג רמת הלייזר
        Debug.Log("Laser upgraded to level: " + laserLevel);
    }

    public void Shoot()
    {
        if (laserLevel == 1)
        {
            // ירי רגיל
            Debug.Log("Shooting normal laser");
        }
        else if (laserLevel == 2)
        {
            // ירי כפול או חזק יותר
            Debug.Log("Shooting upgraded laser!");
        }
    }
}

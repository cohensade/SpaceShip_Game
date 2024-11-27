using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter : ClickSpawner
{
    [SerializeField]
    [Tooltip("How many points to add to the shooter, if the laser hits its target")]
    int pointsToAdd = 1;

    [SerializeField]
    [Tooltip("Current laser level")]
    private int laserLevel = 1; // רמת הלייזר

    [SerializeField]
    [Tooltip("Number of laser shots at level 4 and above")]
    private int numWideShots = 7; // מספר הלייזרים בירי רחב

    // A reference to the field that holds the score that has to be updated when the laser hits its target.
    NumberField scoreField;

    private void Start()
    {
        scoreField = GetComponentInChildren<NumberField>();
        if (!scoreField)
            Debug.LogError($"No child of {gameObject.name} has a NumberField component!");
    }

    // פונקציה לשדרוג רמת הלייזר
    public void UpgradeLaser()
    {
        laserLevel++; // העלאת רמת הלייזר
        Debug.Log("Laser level upgraded to: " + laserLevel);
    }

    protected override GameObject spawnObject()
    {
        // ירי לייזר רחב ברמה 4 ומעלה
        if (laserLevel >= 4)
        {
            Debug.Log("Laser level 4 activated! Shooting wide laser.");

            // יירוי לייזרים במיקומים שונים
            for (int i = 0; i < numWideShots; i++)
            {
                float angle = -45 + (90f / (numWideShots - 1)) * i; // מפזר את הקרניים בזווית רחבה
                GameObject wideLaser = Instantiate(base.spawnObject(), transform.position, Quaternion.Euler(0, 0, angle));

                // קביעת המהירות של הלייזר בזווית
                wideLaser.GetComponent<Rigidbody2D>().linearVelocity = Quaternion.Euler(0, 0, angle) * Vector2.up * 10;

                // עדכון הנקודות עבור כל לייזר
                ScoreAdder wideLaserScoreAdder = wideLaser.GetComponent<ScoreAdder>();
                if (wideLaserScoreAdder)
                {
                    wideLaserScoreAdder.SetScoreField(scoreField).SetPointsToAdd(pointsToAdd);
                }
            }

            return null; // כבר יירינו את הלייזרים הרחבים
        }

        // ירי רגיל ברמות נמוכות יותר
        GameObject newObject = base.spawnObject();

        // Modify the text field of the new object.
        ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
        if (newObjectScoreAdder)
            newObjectScoreAdder.SetScoreField(scoreField).SetPointsToAdd(pointsToAdd);

        // ירי כפול או משולש ברמות נמוכות מ-4
        if (laserLevel >= 2)
        {
            // ירי לייזר נוסף בזווית שונה
            GameObject extraLaser = Instantiate(newObject, transform.position, Quaternion.Euler(0, 0, 10));
            extraLaser.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(1, 1).normalized * 10;
        }

        if (laserLevel >= 3)
        {
            // ירי נוסף בכיוון הפוך
            GameObject thirdLaser = Instantiate(newObject, transform.position, Quaternion.Euler(0, 0, -10));
            thirdLaser.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-1, 1).normalized * 10;
        }

        return newObject;
    }
}

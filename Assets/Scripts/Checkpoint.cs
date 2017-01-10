using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    [System.NonSerialized]
    public int index;
    [System.NonSerialized]
    public LevelManager levelManager;

    public bool lastChekpoint;

    void OnTriggerEnter()
    {
        if (!lastChekpoint)
        {
            levelManager.checkpoints.Remove(this);
            if (levelManager.checkpoints.Count <= 0)
            {
                levelManager.LevelEnded = true;
            }

            if (transform.parent)
                Destroy(transform.parent.gameObject);
            else
                Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(lastChekpoint && other.tag == "Player")
        {
            Transform t_RotatingObject = other.transform;
            Transform t_Reference = other.transform;
            t_Reference.eulerAngles = new Vector3(0, t_RotatingObject.eulerAngles.y, 0); // only Y axis, meaning right & left turns.

           
            float f_AngleBetween = Vector3.Angle(t_Reference.forward, transform.up); // angle between the rotating object's forward , but only affected by Y axis, and the direction from origin to rotating object.

            //Debug.Log(f_AngleBetween);
            if(Vector3.Distance(transform.position, other.transform.position) < 0.75f && f_AngleBetween < 2f && levelManager.checkpoints.Count <= 1)
            {
                GameManager.i.LevelEnd();
            }
        }
    }
}

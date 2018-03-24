using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {

    private bool isRewinding = false;

    [SerializeField]
    private KeyCode Key = KeyCode.T;

    [SerializeField]
    private float RecordTime = 5f;

    [SerializeField]
<<<<<<< HEAD
    private int SpeedRewind = 2;
=======
    private int SpeedRewind = 1;
>>>>>>> Pierre

    List<PointInTime> pointsInTime;

    Rigidbody rb;
    
    private int nbframe = 0;

	void Start () {
        if (SpeedRewind < 1)
            SpeedRewind = 1;
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (nbframe <= 0)
        {
            pointsInTime = new List<PointInTime>();
            nbframe = 0;
            isRewinding = false;
        }
        if (isRewinding)
        {
            Rewind();
        }
        else
            Record();
    }
    // Update is called once per frame
    void Update()
    {   if (Input.GetKeyDown(Key))
            StartRewind();
    }


    void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
        if (pointsInTime.Count < Mathf.Round(RecordTime / Time.fixedDeltaTime))
            nbframe = pointsInTime.Count;
        else
            nbframe = (int)(RecordTime / Time.fixedDeltaTime);
    }

    void Rewind()
    {
        if (nbframe > 0)
        {
            /*if (pointsInTime.Count < nbframe)
            {
                nbframe = pointsInTime.Count;
                Debug.Log("Condtion inutile ?!?!?");
            }*/
            if (pointsInTime.Count > 0)
            {
                PointInTime pointInTime = pointsInTime[0];
                transform.root.position = pointInTime.position;
                transform.root.rotation = pointInTime.rotation;
                for (int i = 0; i < SpeedRewind && pointsInTime.Count >= SpeedRewind; i++)
                {
                    pointsInTime.RemoveAt(0);
                }
            }
            nbframe -= SpeedRewind;
        }
    }

    void Record()
    {
        if (pointsInTime.Count > Mathf.Round(RecordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }
        pointsInTime.Insert(0, new PointInTime(transform.root.position, transform.root.rotation));
        if (nbframe < (int)(RecordTime / Time.fixedDeltaTime))
            nbframe += 1;
    }
}
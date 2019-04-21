using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    [Header("Targets")]
    public static List<GameObject> targets;

    [Header("SmooothSettings")]
    public float smoothTime = .5f;

    [Header("OffsetSettings")]
    public Vector3 offset;

    [Header("CamDefaultSettings")]
    public Quaternion defaultCamRot;
    public Vector3 defaultCamPos;

    [Header("CamZoomSettings")]
    public float defaultZoom = 60f;
    public float minZoom = 20f;
    public float maxZoom = 5f;
    public float zoomLimiter = 25f;

    [Header("CamTimeSettings")]
    public float timeToTarget;
    public float timeToStart;
    public static int counter;

    Camera cam;
    Vector3 velocity;
    bool start_looking_planets;

    private void Start()
    {
        targets = new List<GameObject>();
        counter = 0;
        cam = GetComponent<Camera>();
        defaultCamRot = cam.transform.rotation;
        defaultCamPos = cam.transform.position;
        cam.fieldOfView = defaultZoom;
        start_looking_planets = false;
        StartCoroutine(WaitToStartLooking(timeToStart));
    }

    void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }
        if (start_looking_planets)
        {
            Move();
            Zoom();
        }

        //Stop coroutine and start again
        if (Input.GetKeyDown("space"))
        {
            StopAllCoroutines();
            start_looking_planets = false;
            //Reset Cam
            cam.transform.rotation = defaultCamRot;
            cam.transform.position = defaultCamPos;
            cam.fieldOfView = defaultZoom;
            StartCoroutine(WaitToStartLooking(timeToStart));
        }
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetTargetSize());
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    Vector3 GetCenterPoint()
    {
        Bounds bounds = new Bounds(targets[counter].transform.position, Vector3.zero);
        bounds.Encapsulate(targets[counter].transform.position);
        return bounds.center;
    }

    float GetTargetSize()
    {
        return targets[counter].transform.localScale.x;
    }

    //Waiting to change target for looking
    public IEnumerator WaitToChangeTarget(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (counter == targets.Count - 1)
            {
                counter = 0;
            }
            else
            {
                counter++;
            }
            print("Actual Planet: " + targets[counter].name);
        }
    }
    //Waiting to start looking planets
    public IEnumerator WaitToStartLooking(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (start_looking_planets == false)
            {
                StartCoroutine(WaitToChangeTarget(timeToTarget));
                start_looking_planets = true;
                cam.transform.rotation = Quaternion.Euler(0, 180, 0);
                counter = 0;
            }
        }
    }


}

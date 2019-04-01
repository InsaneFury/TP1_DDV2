using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class camera_movement : MonoBehaviour {

    public List<Transform> targets = new List<Transform>();

    public float smoothTime = .5f;
    Vector3 velocity;
    public Vector3 offset;

    public Quaternion defaultCamRot;
    public Vector3 defaultCamPos;

    public float minZoom = 20f;
    public float maxZoom = 5f;
    public float zoomLimiter = 25f;

    Camera cam;

    public float timeToTarget;
    public float timeToStart;
    public static int counter;
    bool start_looking_planets;

    private void Start() {
        counter = 0;
        cam = GetComponent<Camera>();
        defaultCamRot = cam.transform.rotation;
        defaultCamPos = cam.transform.position;
        start_looking_planets = false;
        StartCoroutine(WaitToStartLooking(timeToStart));
    }

    void LateUpdate() {
        if (targets.Count == 0) {
            return;
        }
        if (start_looking_planets) {
            
            Move();
            Zoom();

            print("Actual Planet: " + targets[counter].name);
        }
        
        //Stop coroutine and start again
        if (Input.GetKeyDown("space")) {
            StopAllCoroutines();
            start_looking_planets = false;
            //Reset Cam
            cam.transform.rotation = defaultCamRot;
            cam.transform.position = defaultCamPos;
            StartCoroutine(WaitToStartLooking(timeToStart));
        }  
    }

    void Move() {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Zoom() {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetTargetSize());
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView,newZoom,Time.deltaTime);
    }

    Vector3 GetCenterPoint() {
        var bounds = new Bounds(targets[counter].position, Vector3.zero);
        bounds.Encapsulate(targets[counter].position);
        return bounds.center;
    }

     float GetTargetSize() {

        return targets[counter].localScale.x;
     }

    //Waiting to change target for looking
    public IEnumerator WaitToChangeTarget(float waitTime) {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            if (counter == targets.Count - 1) {
                counter = 0;
            }
            else {
                counter++;
            }
        }
    }
    //Waiting to start looking planets
    public IEnumerator WaitToStartLooking(float waitTime) {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            if (start_looking_planets == false) {
                StartCoroutine(WaitToChangeTarget(timeToTarget));
                start_looking_planets = true;
                cam.transform.rotation = Quaternion.Euler(0, 180, 0);
                counter = 0;
            }
        }
    }


}

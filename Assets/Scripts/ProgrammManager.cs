using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ProgrammManager : MonoBehaviour
{

    
    [Header("Put your planeMarker here")] 
    [SerializeField] 
    private GameObject PlaneMarkerPrefab;

    [SerializeField] 
    private TextMeshPro TextObject;


    private ARRaycastManager ARRaycastManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        PlaneMarkerPrefab.SetActive(false);
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
       ShowMarker();
    }

    void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        
        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0) // Срабатывает в случае, если луч пересек плоскость
        {
            var pos = hits[0].pose.position;
            PlaneMarkerPrefab.transform.position = pos;
            
            TextObject.text = "d " + hits[0].distance.ToString("0.##");

            PlaneMarkerPrefab.SetActive(true);
        }
    }
}

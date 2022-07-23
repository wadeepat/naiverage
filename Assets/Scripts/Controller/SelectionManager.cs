using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "enemy";
    // [SerializeField] private Material highlightMaterial;
    // [SerializeField] private Material defaultMaterial;

    private Transform _selection;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (_selection != null)
        // {
        //     var selectionRenderer = _selection.GetComponent<Renderer>();
        //     selectionRenderer.material = defaultMaterial;
        //     _selection = null;
        // }
        RaycastHit HitInfo;
        Transform cameraTransform = Camera.main.transform;
        if (Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out HitInfo, 100.0f))
                Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 100.0f, Color.yellow);
        }
        // var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hit;
        // if (Physics.Raycast(ray, out hit))
        // {
        //     var selection = hit.transform;
        //     if (selection.CompareTag(selectableTag))
        //     {
        //         Debug.Log("hit");
        //         // var selectionRenderer = hit.transform.GetComponent<Renderer>();
        //         // if (selectionRenderer != null)
        //         // {
        //         // selectionRenderer.material = highlightMaterial;
        //         // }
        //         // _selection = selection;
        //     }

        // }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerBehaviour : MonoBehaviour
{
    private NavMeshAgent _nma;
    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        _nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            _nma.destination = hit.point;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        Debug.Log("Trigger");
        if (c.gameObject.CompareTag("Coin"))
        {
            Destroy(c.gameObject);
            coins++;
        }
    }
}

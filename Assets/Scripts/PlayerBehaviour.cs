using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using NaughtyAttributes;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField, HideInInspector] private NavMeshAgent _nma;
    [SerializeField, ReadOnly] private int coins;

    void Reset()
    {
        _nma = GetComponent<NavMeshAgent>();
    }

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
        if (c.gameObject.CompareTag("Coin"))
        {
            Destroy(c.gameObject);
            coins++;
        }
    }
}

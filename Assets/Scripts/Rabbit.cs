using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rabbit : MonoBehaviour
{
    [SerializeField]
    private GameObject rabbit;
    private NavMeshAgent _agent;

    private float _halfSizeX;
    private float _halfSizeZ;
    private Vector3 _randomTarget;

    // Start is called before the first frame update
    private void OnEnable()
    {   
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        _agent = GetComponent<NavMeshAgent>();
        _halfSizeX = TrainNavMesh.Area.GetComponent<BoxCollider>().bounds.size.x / 2;
        _halfSizeZ = TrainNavMesh.Area.GetComponent<BoxCollider>().bounds.size.z / 2;
        rabbit.gameObject.SetActive(true);
        _agent.enabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
        _agent.SetDestination(_randomTarget);
        if((transform.position - PlayerTransform.TransformOfPlayer.position).sqrMagnitude < 10)
        {
            _randomTarget = GetRandomPoint();            
        }
    }

    private Vector3 GetRandomPoint()
    {
        float randomX = Random.Range(TrainNavMesh.Area.position.x + _halfSizeX,TrainNavMesh.Area.position.x - _halfSizeX);
        float randomZ = Random.Range(TrainNavMesh.Area.position.z + _halfSizeZ, TrainNavMesh.Area.position.z - _halfSizeZ);
        return new Vector3(randomX,transform.position.y,randomZ);
    }




}

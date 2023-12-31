using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rabbit : MonoBehaviour
{
    private NavMeshAgent _agent;

    private float _halfSizeX;
    private float _halfSizeZ;
    private Vector3 _randomTarget;

    // Start is called before the first frame update
    private void OnEnable()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        _agent = GetComponent<NavMeshAgent>();
        _halfSizeX = TrainNavMesh.Area.GetComponent<BoxCollider>().bounds.size.x / 2;
        _halfSizeZ = TrainNavMesh.Area.GetComponent<BoxCollider>().bounds.size.z / 2;
        transform.GetChild(1).gameObject.SetActive(false);
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

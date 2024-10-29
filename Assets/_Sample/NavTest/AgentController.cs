using MyFps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MySample
{
    public class AgentController : MonoBehaviour
    {
        #region Variables
        private NavMeshAgent agent;
        [SerializeField] private Vector3 worldPosition; //이동 목표지점
        #endregion
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                SetDestinationToPosition();

            }
        }
        void SetDestinationToPosition()
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

}

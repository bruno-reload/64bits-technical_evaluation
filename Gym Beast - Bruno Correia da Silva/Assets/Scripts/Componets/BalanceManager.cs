
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Player
{

    [System.Serializable]
    public class BalanceManager
    {

        private const float distanceBtween = .5f;
        private const float maxDistanceToActiveDrag = .4f;

        [SerializeField] private StackManager obj;
        private PlayerController playerController;

        private float speedMoviment;
        private float speedLookt;
        private float maxDistanceToDrag;
        public UnityEvent<Transform> newItem;


        public List<Transform> ObjList { get => obj.Stack; }
        public StackManager Stack { get { return obj; } }

        public Transform SteadyBaseRun { get; set; }
        public Transform SteadyBaseIdle { get; set; }

        public BalanceManager(StackManager obj)
        {
            this.obj = obj;
            this.playerController = obj.Player;
            newItem = new UnityEvent<Transform>();
            speedMoviment = playerController.GetComponent<ToCollect>().trackMoviment.speedMoviment;
            speedLookt = playerController.GetComponent<ToCollect>().trackMoviment.speedLookt;
            maxDistanceToDrag = playerController.GetComponent<ToCollect>().trackMoviment.maxDistanceToDrag;
        }

        public void Update()
        {
            for (int i = 1; i < ObjList.Count; i++)
            {
                int previous = i - 1;

                Translate(i, previous);
                Ratation(i, previous);
            }
        }


        private void Ratation(int i, int previous)
        {
            Vector3 direction = (ObjList[i].position - ObjList[previous].position);

            ObjList[i].rotation = Quaternion.LookRotation(ObjList[0].forward);

            if (Vector3.Angle(direction, ObjList[previous].up) > 0)
            {
                Transform child = ObjList[i].GetChild(0);
                //child.rotation = Quaternion.LookRotation(Vector3.Cross(direction, ObjList[i].right));
                child.rotation = Quaternion.LookRotation(Vector3.Cross(direction, ObjList[i].right) + Vector3.up);
                child.Rotate(Quaternion.Euler(Vector3.forward).eulerAngles, 100);
            }
            Debug.DrawLine(ObjList[i].position, ObjList[i].position + direction * 10);
        }

        private void Translate(int i, int previous)
        {
            if (Vector3.Angle(ObjList[i].up, ObjList[previous].up) != 0)
            {
                Vector3 pFrom = ObjList[i].position;
                Vector3 pTo = ObjList[previous].position + ObjList[previous].up * distanceBtween;
                Vector3 positino = Vector3.MoveTowards(pFrom, pTo, Mathf.Pow(speedMoviment * ((pFrom - pTo).magnitude + 0.2f), 2.0f));
                ObjList[i].position = positino;

                //// fixa a posição do kull prefab
                ObjList[i].GetComponentInChildren<FixedJoint>().anchor = ObjList[0].localPosition;
            }
        }
        public void ResetTransforms()
        {
            ObjList[Stack.PointSelect].transform.position = ObjList[Stack.PointPrevious].position + ObjList[Stack.PointPrevious].up * distanceBtween;
            ObjList[Stack.PointSelect].rotation = ObjList[Stack.PointPrevious].transform.rotation;
        }

        public void ChangeParentSteadyBaseIdle()
        {
            if (ObjList.Count > 0)
            {
                ObjList[0] = playerController.GetComponent<ToCollect>().steadyBaseIdle;
            }
        }

        public void ChangeParentSteadyBaseRun()
        {

            if (ObjList.Count > 0)
            {
                ObjList[0] = playerController.GetComponent<ToCollect>().steadyBaseRun;
            }
        }
    }
}

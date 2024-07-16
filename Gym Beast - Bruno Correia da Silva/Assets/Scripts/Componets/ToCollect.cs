using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class ToCollect : MonoBehaviour
    {
        public Transform steadyBaseRun;
        public Transform steadyBaseIdle;
        private GameObject readyToCollect;
        private BalanceManager balanceManager;
        public trackMoviment trackMoviment;
        public List<GameObject> debug;


        [SerializeField] public BalanceManager BalanceManager { get { return balanceManager; } }
        private void Awake()
        {
            PlayerController player = GetComponent<PlayerController>();
            balanceManager = new BalanceManager(new StackManager(steadyBaseIdle, player));
            balanceManager.SteadyBaseRun = steadyBaseRun;
            balanceManager.SteadyBaseIdle = steadyBaseIdle;
        }
        private void Start()
        {
            foreach (GameObject item in debug)
            {
                readyToCollect = item;
                Collected();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Collectable"))
            {
                readyToCollect = other.gameObject;
            }
        }

        public void Collected()
        {
            if (readyToCollect != null)
            {
                EnemyController enemy = readyToCollect.GetComponent<EnemyController>();
                balanceManager.Stack.Push(ref readyToCollect);
                readyToCollect.gameObject.tag = "Untagged";
                balanceManager.ResetTransforms();
                enemy.RagDoll.DisableRagDoll();
                (enemy as EnemyController).TryDead();
            }
            readyToCollect = null;
        }

        private void FixedUpdate()
        {
            balanceManager.Update();
        }
    }
}

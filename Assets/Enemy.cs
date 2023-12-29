using System.Collections;
using System.Collections.Generic;
using RenownedGames.AITree;
using UnityEngine;

namespace LlamAcademy.BehaviorTree
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private GameObject Player; // Assuming GameObject, change the type accordingly
        [SerializeField] private BehaviourRunner BehaviorRunner;

        [SerializeField] private PlayerSensor ChaseSensor; // Assuming PlayerSensor is the correct type
        [SerializeField] private PlayerSensor SpitSensor; // Assuming PlayerSensor is the correct type
        [SerializeField] private PlayerSensor MeleeSensor; // Assuming PlayerSensor is the correct type

        [Header("Attack Configs")]
        [SerializeField][Range(0.33f, 5f)] private float MeleeCooldown = 2f;


        [Header("Debug")]
        [SerializeField] private bool IsInChaseRange;
        [SerializeField] private bool IsInSpitRange;
        [SerializeField] private bool IsInMeleeRange;
        [SerializeField] private float LastMeleeTime;

        private void Start()
        {
            // Ensure that ChaseSensor, SpitSensor, and MeleeSensor are assigned before subscribing to events
            if (ChaseSensor != null)
            {
                ChaseSensor.OnPlayerEnter += ChaseSensorOnOnPlayerEnter;
                ChaseSensor.OnPlayerExit += ChaseSensorOnOnPlayerExit;
            }

           // if (SpitSensor != null)
         //   {
           //     SpitSensor.OnPlayerEnter += SpitSensorOnOnPlayerEnter;
           //     SpitSensor.OnPlayerExit += SpitSensorOnOnPlayerExit;
            //}

            if (MeleeSensor != null)
            {
                MeleeSensor.OnPlayerEnter += MeleeSensorOnOnPlayerEnter;
                MeleeSensor.OnPlayerExit += MeleeSensorOnOnPlayerExit;
            }
        }

        private void Update()
        {
            if (BehaviorRunner == null)
            {
                return;
            }

            Blackboard blackboard = BehaviorRunner.GetBlackboard();

            SetBlackboardValue(blackboard, key: "Player", Player.transform);

            SetBlackboardValue(blackboard, key: "IsInChaseRange", IsInChaseRange);

            SetBlackboardValue(blackboard, key: "IsInMeleeRange", IsInMeleeRange);

            SetBlackboardValue(blackboard, key:"CanMelee", boolValue:LastMeleeTime + MeleeCooldown <= Time.time);


        }

        private void SetBlackboardValue(Blackboard blackboard, string key, Transform transform)
        {
            if (blackboard.TryGetKey(key, out TransformKey transformKey))
            {
                transformKey.SetValue(transform);
            }
        }

        private void SetBlackboardValue(Blackboard blackboard, string key, bool boolValue)
        {
            if (blackboard.TryGetKey(key, out BoolKey boolKey))
            {
               boolKey.SetValue(boolValue);
            }
        }

        public void OnMelee()
        {
            LastMeleeTime = Time.time;
        }

        private void ChaseSensorOnOnPlayerExit(Vector3 lastKnownPosition) => IsInChaseRange = false;
        private void ChaseSensorOnOnPlayerEnter(Transform player) => IsInChaseRange = true;

        private void SpitSensorOnOnPlayerExit(Vector3 lastKnownPosition) => IsInSpitRange = false;
        private void SpitSensorOnOnPlayerEnter(Transform player) => IsInSpitRange = true;

        private void MeleeSensorOnOnPlayerExit(Vector3 lastKnownPosition) => IsInMeleeRange = false;
        private void MeleeSensorOnOnPlayerEnter(Transform player) => IsInMeleeRange = true;
    }
}

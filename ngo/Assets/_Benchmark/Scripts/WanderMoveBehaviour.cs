using StinkySteak.NetcodeBenchmark;
using Unity.Netcode;
using UnityEngine;

namespace StinkySteak.NGOBenchmark
{
    public class WanderMoveBehaviour : NetworkBehaviour
    {
        [SerializeField] private BehaviourConfig _config;
        private WanderMoveWrapper _wrapper;

        public override void OnNetworkSpawn()
        {
            _config.ApplyConfig(ref _wrapper);
            _wrapper.NetworkStart(transform);
            NetworkManager.NetworkTickSystem.Tick += OnTick;
        }

        private void OnTick()
        {
            if (!IsServer) return;

            _wrapper.NetworkUpdate(transform);
        }
    }
}
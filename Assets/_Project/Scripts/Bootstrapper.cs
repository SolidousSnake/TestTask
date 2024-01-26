using _Project.MVP.Factory;
using UnityEngine;

namespace _Project.Bootstrappers
{
    public sealed class Bootstrapper : MonoBehaviour
    {
        [Header("Model")]
        [SerializeField] private float _cubeSpeed;
        [SerializeField] private float _disappearDistance;
        [SerializeField] private float _spawnDelay;

        [Header("View")]
        [SerializeField] private FactoryView _factoryView;
        [SerializeField] private Transform _parent;
        [SerializeField] private Cube.Cube _cubePrefab;

        private FactoryPresenter _presenter;

        private void Start()
        {
            FactoryModel model = new FactoryModel(_cubeSpeed, _disappearDistance, _spawnDelay);
            _presenter = new FactoryPresenter(model, _cubePrefab, _parent);

            _factoryView.Initialize(_presenter, _spawnDelay, _disappearDistance, _cubeSpeed);;            
        }

        private void OnApplicationQuit()
        {
            _presenter.Dispose();
        }
    }
}

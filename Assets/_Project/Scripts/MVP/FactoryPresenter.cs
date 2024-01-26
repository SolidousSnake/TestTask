using System.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine;

namespace _Project.MVP.Factory
{
    public sealed class FactoryPresenter : IDisposable
    {
        private readonly FactoryModel _model;
        private readonly Transform _parent;

        private readonly CancellationTokenSource _cancellationTokenSource;

        public FactoryPresenter(FactoryModel model, Cube.Cube prefab, Transform parent)
        {
            _model = model;
            _parent = parent;
            _cancellationTokenSource = new CancellationTokenSource();
            CreateCubes(prefab);
        }

        public void SetSpeed(float value)
        {
            if(value > 0)
                _model.CubeSpeed = value;
        }

        public void SetDistance(float value)
        {
            if (value > 0)
                _model.DisappearDistance = value;
        }

        public void SetDelay(float value)
        {
            if (value > 0)
                _model.SpawnDelay = value;
        }

        private async void CreateCubes(Cube.Cube prefab)
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested) 
            {
                Cube.Cube cube = UnityEngine.Object.Instantiate(prefab, _parent.position
                    , _parent.rotation, _parent);
                cube.Initialize(_model);
                await Task.Delay(TimeSpan.FromSeconds(_model.SpawnDelay));
            }
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}

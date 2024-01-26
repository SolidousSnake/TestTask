using _Project.MVP.Factory;
using DG.Tweening;
using UnityEngine;

namespace _Project.Cube
{
    public sealed class Cube : MonoBehaviour
    {
        private FactoryModel _model;

        public void Initialize(FactoryModel model) 
        {
            _model = model;
            Move();
        }

        private void Move()
        {
            transform.DOMoveX(_model.DisappearDistance, _model.CubeSpeed).OnComplete(() => Destroy(gameObject));
        }
    }
}
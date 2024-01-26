using TMPro;
using UnityEngine;

namespace _Project.MVP.Factory
{
    public sealed class FactoryView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _timeInputField;
        [SerializeField] private TMP_InputField _distanceInputField;
        [SerializeField] private TMP_InputField _speedInputField;

        private FactoryPresenter _cubePresenter;

        public void Initialize(FactoryPresenter cubePresenter, float time
            , float distance, float speed)
        {
            _cubePresenter = cubePresenter;
            _timeInputField.text = $"{time}";
            _distanceInputField.text = $"{distance}";
            _speedInputField.text = $"{speed}";
            RegisterListeners();
        }

        private void RegisterListeners()
        {
            _timeInputField.onValueChanged.AddListener(delegate 
            {
                _cubePresenter.SetDelay(float.Parse(_timeInputField.text));
            });

            _distanceInputField.onValueChanged.AddListener(delegate
            {
                _cubePresenter.SetDistance(float.Parse(_distanceInputField.text));
            });

            _speedInputField.onValueChanged.AddListener(delegate
            {
                _cubePresenter.SetSpeed(float.Parse(_speedInputField.text));
            });
        }
    }
}
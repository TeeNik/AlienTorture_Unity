using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _target;
    private Rigidbody2D _rb;
    private GameObject _player;

    private CompositeDisposable _subscriptions;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _subscriptions = new CompositeDisposable();
        _subscriptions.Add(GameLayer.Instance.Player.Subscribe((OnPlayerChanged)));
    }

    private void OnPlayerChanged(CharacterModel characterModel)
    {
        _player = characterModel.Object;
    }

    void Update()
    {
        if (_player != null)
        {
            var mousePosition = Input.mousePosition;
            if (mousePosition.x >= Screen.width || mousePosition.x <= 0 || mousePosition.y <= 0 || mousePosition.y >= Screen.height)
            {
                Vector3 mouseDir = mousePosition - new Vector3(Screen.width, Screen.height) / 2;
                _target = _player.transform.position + mouseDir.normalized * 4;
            }
            else
                _target = _player.transform.position;
            if ((transform.position - _target).magnitude > 0.5)
                _rb.velocity = (_target - transform.position).normalized * 80;
        }
    }

    void OnDestroy()
    {
        Utils.DisposeAndSetNull(ref _subscriptions);
    }
}

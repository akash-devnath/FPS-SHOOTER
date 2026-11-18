using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float roataionSpeed = 100f;
    const string PLAYER_TAG = "Player";

    private void Update()
    {
        transform.Rotate(0f, roataionSpeed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);
            Destroy(this.gameObject);
        }
    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);
}

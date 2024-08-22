using UnityEngine;

public class BonusHP : MonoBehaviour
{
    [SerializeField] private float healthCount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IPlayer player))
        {
            player.GetHeals(healthCount);
            Destroy(gameObject);
        }
    }
}

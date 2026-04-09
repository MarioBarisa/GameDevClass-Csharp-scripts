using UnityEngine;

public class HappyCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        other.GetComponent<CoinCollector>().AddCoin();
        Destroy(gameObject);
    }
}

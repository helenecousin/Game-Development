using UnityEngine;

public class IngredientCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCollection playerCollection = 
                other.GetComponent<PlayerCollection>();
            
            if (playerCollection != null)
            {
                playerCollection.CollectIngredient();
            }

            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    //ingredients only contribute to potion meter (broom power-up)
        
    //number of ingredients needed to fill potion
    [SerializeField] private int maxPotion = 10;

    //number of ingredients player has collected
    private int potionAmount = 0;

    //function IngredientCollect script calls when player touches an ingredient
    public void CollectIngredient()
    {
        if (potionAmount < maxPotion)
        {
            potionAmount++;

            Debug.Log("Potion: " + potionAmount + "/" + maxPotion);
        }
    }
}
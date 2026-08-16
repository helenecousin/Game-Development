using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    //ingredients only contribute to potion meter (broom power-up)
        
    //number of ingredients needed to fill potion
    [SerializeField] private int maxPotion = 15;

    //stores number of ingredients player has collected during current run
    private int potionAmount = 0;

    //function IngredientCollect script calls when player touches an ingredient
    public void CollectIngredient()
    {
        //this only increases the potion amount if it is below the maximum
        //prevents value from continuing to increase after potion meter is already full
        if (potionAmount < maxPotion)
        {
            potionAmount++;

            Debug.Log("Potion: " + potionAmount + "/" + maxPotion);
            
            //activates booster once enough ingredients have been collected
            if (potionAmount >= maxPotion)
            {
                PlayerBooster booster = GetComponent<PlayerBooster>();

                //checks that player has a playerbooster component before trying to activate
                //prevents NullReferenceException
                if (booster != null)
                {
                    booster.ActivateBooster();

                    //resets the potion amount so that the meter can fill again
                    potionAmount = 0;
                }
            }
        }
    }
    
    //returns current potion amount for UI to display
    public int GetPotionAmount()
    {
        return potionAmount;
    }

    //returns maximum number of ingredients required to fill potion
    //used by UI to calculate fill percentage
    public int GetMaxPotion()
    {
        return maxPotion;
    }
}
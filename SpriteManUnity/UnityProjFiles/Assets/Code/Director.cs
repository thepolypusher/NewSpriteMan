using UnityEngine;

namespace Assets.Code
{
    public class Director : MonoBehaviour
    {
        public float DirectorFudge = 1.0f;
        
        public int _currentBudget;

        public void AddToBudget(int amount )
        {
            float newBudgetAmount = _currentBudget;
            newBudgetAmount += amount * DirectorFudge;
            _currentBudget = (int) newBudgetAmount;
            }
    }
}

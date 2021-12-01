using UnityEngine;
using System;

namespace Raketa420
{
   public class BarBank : MonoBehaviour
   {
      private int maxHapinnessPointsAmount;
      private int currentHappinessPointsAmount;

      public static event Action<float> OnHappinessPointsChanged;

      private void Start()
      {
         Initialize();
      }

      private void Initialize()
      {
         var gameSession = FindObjectOfType<GameSession>();

         maxHapinnessPointsAmount = gameSession.Data.MaxHappinessPointsAmount;
         currentHappinessPointsAmount = 20;
      }

      public void IncreaseHappinnessPoints(int amount)
      {
         if (amount > 0)
         {
            currentHappinessPointsAmount += amount;

            if (currentHappinessPointsAmount > maxHapinnessPointsAmount)
            {
               currentHappinessPointsAmount = maxHapinnessPointsAmount;
            }
         }
         else
         {
            Debug.LogError("Нельзя добавить отрицательное значение");
         }

         ChangeHappinessPoints();
      }

      public void DecreaseHappinnessPoints(int amount)
      {
         if (amount > 0)
         {
            currentHappinessPointsAmount -= amount;

            if (currentHappinessPointsAmount < 0)
            {
               currentHappinessPointsAmount = 0;
            }
         }
         else
         {
            Debug.LogError("Нельзя вычесть отрицательное значение");
         }

         ChangeHappinessPoints();
      }

      private void ChangeHappinessPoints()
      {
         var normalized = currentHappinessPointsAmount / maxHapinnessPointsAmount;
         OnHappinessPointsChanged?.Invoke(normalized);
      }
   }
}
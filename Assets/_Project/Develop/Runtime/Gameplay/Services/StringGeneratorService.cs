using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Services
{
    public static class StringGeneratorService
    {
        public static string GenerateString(int length, string symbolsSet)
        {
            string generatedString = "";
            
            for (int i = 0; i < length; i++)
                generatedString += symbolsSet[Random.Range(0, symbolsSet.Length)];
            
            return generatedString;
        }
    }
}
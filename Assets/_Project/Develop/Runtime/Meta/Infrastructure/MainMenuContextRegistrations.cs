using _Project.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            Debug.Log("Process registration services on MainMenu scene");
        }
    }
}
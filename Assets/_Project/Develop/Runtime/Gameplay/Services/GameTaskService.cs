using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Services
{
    public class GameTaskService
    {
        private readonly ReactiveVariable<string> _taskString;
        
        public GameTaskService(ReactiveVariable<string> taskString)
        {
            _taskString = taskString;
        }

        public IReadOnlyVariable<string> TaskString => _taskString;
        
        public void SetTaskString(string value) => _taskString.Value = value;
    }
}
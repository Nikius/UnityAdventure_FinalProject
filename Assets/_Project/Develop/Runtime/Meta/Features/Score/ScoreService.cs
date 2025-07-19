using System;
using System.Collections.Generic;
using _Project.Develop.Runtime.Utilities.DataManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Meta.Features.Score
{
    public class ScoreService: IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private readonly Dictionary<ScoreTypes, ReactiveVariable<int>> _scores;

        public ScoreService(
            Dictionary<ScoreTypes, ReactiveVariable<int>> scores,
            PlayerDataProvider playerDataProvider
        ) {
            _scores = new Dictionary<ScoreTypes, ReactiveVariable<int>>(scores);
            
            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }
        
        public IReadOnlyVariable<int> GetScore(ScoreTypes type) => _scores[type];

        public void ReadFrom(PlayerData data)
        {
            foreach (KeyValuePair<ScoreTypes, int> score in data.ScoreData)
            {
                if (_scores.ContainsKey(score.Key))
                    _scores[score.Key].Value = score.Value;
                else
                    _scores.Add(score.Key, new ReactiveVariable<int>(score.Value));
            }
        }

        public void WriteTo(PlayerData data)
        {
            foreach (KeyValuePair<ScoreTypes, ReactiveVariable<int>> score in _scores)
                data.ScoreData[score.Key] = score.Value.Value;
        }
        
        private void Add(ScoreTypes type, int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            
            _scores[type].Value += amount;
        }

        public void IncreaseWins() => Add(ScoreTypes.Wins, 1);
        public void IncreaseLooses() => Add(ScoreTypes.Looses, 1);

        public void Reset()
        {
            foreach (KeyValuePair<ScoreTypes, ReactiveVariable<int>> keyValuePair in _scores)
                _scores[keyValuePair.Key].Value = 0;
        }
    }
}
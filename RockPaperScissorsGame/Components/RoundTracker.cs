using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissorsGame.Components
{


    /// <summary>
    ///  this class will track the number of rounds/matched that has been played 
    /// when the number will reach the max value (for example :3)
    /// an event will be raised 
    /// </summary>


    public class RoundTracker
    {
        private readonly int max = 5;
        private int current = 0;

        private void RestartRound() => current = 0;


     public void Increase()
        {
            current += 1;
            if (current == max)
                OnRoundLimitReached(EventArgs.Empty);
        }
        protected virtual void OnRoundLimitReached(EventArgs e)
        {
            RestartRound();
            EventHandler handler = RoundLimitReached;
            handler?.Invoke(this, e);
        }

        public event EventHandler RoundLimitReached;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissorsGame.Components
{
    public class WinningMethod
    {
        private readonly IList<(int, int, bool, bool, string)> winningMethod =
           new List<(int, int, bool, bool, string)>

            { //first value represent the players choice and the second value represent the computer choice
               //class is registered to be injected on components 
               (0,0, false, false, " You both selected Rock, it's a draw"),
               (0,1, false, true, " Paper covers Rock, you lose"),
               (0,2, true, false, " Rock crushes Scissors, you win"),
               (0,3, true, false, " Rock crushes Lizard, you win"),
               (0,4, false, true, " Spock vaporizes Rock, you lose"),
               (1,0, true, false, " Paper covers Rock, you win"),
               (1,1, false, false, " You both selected Paper, it's a draw"),
               (1,2, false, true, " Scissors cuts Paper, you lose"),
               (1,3, false, true, " Lizard eats Paper, you lose"),
               (1,4, true, false, " Paper disproves Spock, you win"),
               (2,0, false, true, " Rock crushes Scissors, you lose"),
               (2,1, true, false, " Scissors cuts Paper, you win"),
               (2,2, false, false, " You both selected Scissors, it's a draw"),
               (2,3, true, false, " Scissors decapitates Lizard, you win"),
               (2,4, false, true, " Spock smashes Scissors, you lose"),
               (3,0, false, true, " Rock crushes Lizard, you lose"),
               (3,1, true, false, " Lizard eats Paper, you win"),
               (3,2, false, true, " Scissors decapitates Lizard, you lose"),
               (3,3, false, false, " You both selected Lizard, it's a draw"),
               (3,4, true, false,  " Lizard poisons Spock, you win"),
               (4,0, true, false,  " Spock vaporizes Rock, you win"),
               (4,1, false, true,  " Paper disproves Spock, you lose"),
               (4,2, true, false,  " Spock smashes Scissors, you win"),
               (4,3, false, true,  " Lizard poisons Spock, you lose"),
               (4,4, false, false, " You both selected Spock, it's a draw")

           };

        public (int, int, bool, bool, string) this[int playerChoice, int computerChoice] =>
            winningMethod.Single(w => w.Item1 == playerChoice && w.Item2 == computerChoice);

    }
}

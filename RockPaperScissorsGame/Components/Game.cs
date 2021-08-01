// this class contains the logic related to game components 
using Microsoft.AspNetCore.Components;
using System;
namespace RockPaperScissorsGame.Components
{
    public partial class Game
    { // the variables
        private int playerScore;
        private int computerScore;
        private string playerSelection;
        private string computerSelection;
        private string message;
        private string info;
        private bool gameEnded;

        private readonly Action<int> playerPicked;
        private readonly Action<int> computerPicked;
        private readonly Action<int, int> bothPartyPicked;

        private readonly Random random;

        // to track the rounds or matches that has been played 
        private RoundTracker roundTracker;


    public Game()


        {
            random = new Random();
            roundTracker = new RoundTracker();

            // Register to this event to get notify when the number of round/match will reach the limit
            roundTracker.RoundLimitReached += (o, arg) =>
            {
                //Numbers of round/match has been reached
                this.info = this.playerScore > this.computerScore ? "You win!" : "You lose computer wins!";

                gameEnded = true;

            };


            playerPicked = (playerChoice) =>
            { // player's choice 
                playerSelection = options[playerChoice];
                computerPicked(playerChoice);
            };



            computerPicked = (playerChoice) =>
            {
                // computer's choice 
                var computerChoice = random.Next(4);
                computerSelection = options[computerChoice];
                StateHasChanged();

                bothPartyPicked(playerChoice, computerChoice);
            
            };

            bothPartyPicked = (playerChoice, computerChoice) => 
            
            { // Who is the winner 

                var (_, _, playerWon, computerWon, message) = WinningMethod[playerChoice, computerChoice];
                this.message = message;
                playerScore = playerWon ? ++playerScore : playerScore;
                computerScore = computerWon ? ++computerScore : computerScore;

                //When both players make a move, the number of round/match played will be increased
                roundTracker.Increase();

                StateHasChanged();
            
            };
        }

        protected override void OnInitialized() => SetDefaultMessage();
        //message for the players when game is started 
        private void SetDefaultMessage() => message = "Pick a Move: First player to win 3 out 5 matches Win!";
        
        private void OnPlayerPicked(int playerChoice) => playerPicked(playerChoice); // players making a choice will start the game 
        
        private void NewGame() // once winner is decided, player will need to start new game 
        {
            gameEnded = false;
            SetDefaultMessage();
            playerScore = computerScore = 0;
            playerSelection = computerSelection = string.Empty;

        }

        [Inject]
        public WinningMethod WinningMethod { get; set; }
       
        
    }
}

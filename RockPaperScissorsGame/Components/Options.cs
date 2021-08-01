using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissorsGame.Components
{
    public class Options
    { // emoji is to be presented as images and to be stored as strings 
        private readonly Dictionary<int, string> options =
            new Dictionary<int, string>
            {
                { 0, "👊"},
                { 1, "🖐"},
                { 2, "✌"},
                { 3, "🦎"},
                { 4, "🖖"}
            };
        //indexer used to retrive the images/emoji from the dictionary 
        // allows choices to treated as an array  - regestered on program.cs to be injected on Game.razor file
        public string this[int optionKey] => options[optionKey];
    }
}

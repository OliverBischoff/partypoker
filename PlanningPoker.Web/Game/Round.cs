using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanningPoker.Web.Game
{
    public class Round
    {
        public Dictionary<Player, string> Cards { get; set; } = new Dictionary<Player, string>();

        public bool IsRevealed { get; set; } = false;

        public List<(Player Player, string Card)> HighestCardsWithPlayer
        {
            get
            {
                var parsedCardValues = Cards.Select(c => (player: c.Key, card: double.Parse(c.Value)));

                return [.. parsedCardValues.Where(p => p.card == parsedCardValues.Max(c => c.card)).Select(max => (max.player, max.card.ToString()))];
            }
        }

        public List<(Player Player, string Card)> LowestCardsWithPlayer
        {
            get
            {
                var parsedCardValues = Cards.Select(c => (player: c.Key, card: double.Parse(c.Value)))
                    .Where(p => !double.IsNaN(p.card));

                return [.. parsedCardValues.Where(p => p.card == parsedCardValues.Min(c => c.card)).Select(max => (max.player, max.card.ToString()))];
            }
        }
    }
}
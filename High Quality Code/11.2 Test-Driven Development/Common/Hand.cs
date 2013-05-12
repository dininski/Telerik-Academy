namespace Poker.Common
{
    using System.Collections.Generic;
    using System.Text;

    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var card in this.Cards)
            {
                sb.AppendFormat("{0} ", card.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}

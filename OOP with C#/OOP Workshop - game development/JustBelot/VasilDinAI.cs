namespace JustBelot.AI.VasilDinAI
{
    using System.Collections.Generic;

    using JustBelot.Common;
    using JustBelot.Common.Extensions;
    using System.Linq;

    public class VasilDinAI : IPlayer
    {
        private readonly Hand hand = new Hand();

        Dictionary<BidType,int> announceStrength = new Dictionary<BidType,int>();


        public VasilDinAI()
        {
            announceStrength.Add(BidType.Spades, 0);
            announceStrength.Add(BidType.Diamonds, 0);
            announceStrength.Add(BidType.Hearts, 0);
            announceStrength.Add(BidType.Clubs, 0);
            announceStrength.Add(BidType.NoTrumps, 0);
            announceStrength.Add(BidType.AllTrumps, 0);

            this.Name = "Vasil's Minion";
        }

        public VasilDinAI(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        private GameInfo Game { get; set; }

        private PlayerPosition Position { get; set; }

        public void StartNewGame(GameInfo gameInfo, PlayerPosition position)
        {
            this.Position = position;
            this.Game = gameInfo;
        }

        public void StartNewDeal(DealInfo dealInfo)
        {
            this.hand.Clear();
        }

        public void AddCards(IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                this.hand.Add(card);
            }
            HandStrength();
        }

        public BidType AskForBid(Contract currentContract, IList<BidType> allowedBids, IList<BidType> previousBids)
        {
            int max = 0;
            BidType currentBid = BidType.Pass;
            foreach (var item in announceStrength)
            {
                if (item.Value > max && allowedBids.Contains(item.Key) && item.Value > 14)
                {
                    max = item.Value;
                    currentBid = item.Key;
                }
                if (item.Value >= 24 && allowedBids.Contains(BidType.Double))
                {
                    currentBid = BidType.Double;
                    break;
                }
                if (item.Value >= 24 && allowedBids.Contains(BidType.ReDouble))
                {
                    currentBid = BidType.ReDouble;
                    break;
                }
            }
            return currentBid;
        }


        public IEnumerable<CardsCombination> AskForCardsCombinations(IEnumerable<CardsCombination> allowedCombinations)
        {
            return allowedCombinations;
        }

        public PlayAction PlayCard(IList<Card> allowedCards, IList<Card> currentTrickCards)
        {
            var cardToPlay = new List<Card>(allowedCards)[0];
            if (currentTrickCards.Count == 3)
            {
                cardToPlay = new List<Card>(allowedCards)[allowedCards.Count - 1];
            }
            this.hand.Remove(cardToPlay);
            return new PlayAction { Card = cardToPlay, AnnounceBeloteIfAvailable = true };
        }

        public void EndOfDeal(DealResult dealResult)
        {
        }

        private void HandStrength()
        {
            foreach (var card in this.hand)
            {
                switch (card.Suit)
                {
                    case CardSuit.Spades:
                        SetHandStrength(card, BidType.Spades);
                        break;
                    case CardSuit.Hearts:
                        SetHandStrength(card, BidType.Hearts);
                        break;
                    case CardSuit.Diamonds:
                        SetHandStrength(card, BidType.Diamonds);
                        break;
                    case CardSuit.Clubs:
                        SetHandStrength(card, BidType.Clubs);
                        break;
                    default:
                        break;
                }
            }
            NoTrumpsStrength();
            AllTrumpsStrength();
        }

       

        private void SetHandStrength(Card card, BidType bidType)
        {
            if (card.Type == CardType.Ten)
            {
                announceStrength[bidType] += 3;
            }
            if (card.Type == CardType.Queen || card.Type == CardType.King)
            {
                announceStrength[bidType] += 2;
            }
            if (card.Type == CardType.Ace)
            {
                announceStrength[bidType] += 5;
            }
            if (card.Type == CardType.Nine)
            {
                announceStrength[bidType] += 6;
            }
            if (card.Type == CardType.Jack)
            {
                announceStrength[bidType] += 10;
            }
            if (card.Type == CardType.Seven || card.Type == CardType.Eight)
            {
                announceStrength[bidType] += 1;
            }
        }


        private void NoTrumpsStrength()
        {
            foreach (var card in hand)
            {
                switch (card.Type)
                {
                    case CardType.Ace:
                        announceStrength[BidType.NoTrumps] += 5;
                        break;
                    case CardType.King:
                        announceStrength[BidType.NoTrumps] += 2;

                        break;
                    case CardType.Queen:
                        announceStrength[BidType.NoTrumps] += 1;
                        break;
                    case CardType.Jack:
                        announceStrength[BidType.NoTrumps] += 1;
                        break;
                    case CardType.Ten:
                        announceStrength[BidType.NoTrumps] += 3;
                        break;
                    case CardType.Nine:
                    case CardType.Eight:
                    case CardType.Seven:
                        break;
                    default:
                        break;
                }
            }
        }

        private void AllTrumpsStrength()
        {
            foreach (var card in hand)
            {
                switch (card.Type)
                {
                    case CardType.Ace:
                        announceStrength[BidType.AllTrumps] +=  1;
                        break;
                    case CardType.King:
                    case CardType.Queen:
                        break;
                    case CardType.Jack:
                        announceStrength[BidType.AllTrumps] += 6;
                        break;
                    case CardType.Ten:
                        break;
                    case CardType.Nine:
                        announceStrength[BidType.AllTrumps] += 3;
                        break;
                    case CardType.Eight:
                    case CardType.Seven:
                        break;
                    default:
                        break;
                }
            }
        }

         //private void CalculateSuitStrength(CardSuit suit)
        //{
        //    foreach (var card in hand)
        //    {
        //        if (card.Suit == suit)
        //        {
        //            switch (card.Suit)
        //            {
        //                case CardSuit.Spades:
        //                    SetHandStrength(card, BidType.Spades);
        //                    break;
        //                case CardSuit.Hearts:
        //                    SetHandStrength(card, BidType.Hearts);
        //                    break;
        //                case CardSuit.Diamonds:
        //                    SetHandStrength(card, BidType.Diamonds);
        //                    break;
        //                case CardSuit.Clubs:
        //                    SetHandStrength(card, BidType.Clubs);
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //    NoTrumpsStrength();
        //}
    }
}

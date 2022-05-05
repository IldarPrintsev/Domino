using DominoApp.Abstract;
using DominoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominoApp.Concrete
{
    public class DominoService : IDominoService
    {
        private bool _chainIsDone = false;
        private Chain _result = new();

        public Chain GetChain(IEnumerable<(int, int)> data)
        {
            var collection = new StoneCollection(data);
            if (collection.Stones.Count == 0)
            {
                return _result;
            }

            foreach (Stone stone in collection.Stones)
            {
                Chain chain = new();
                ContinueChain(stone, chain.DeepCopy(), collection.DeepCopy());
                if (_chainIsDone)
                {
                    return _result;
                }
            }

            return _result;
        }

        public List<(int, int)> ParseInputs()
        {
            Console.Write("Dominoes amount: ");
            int count = int.Parse(Console.ReadLine());

            var result = new List<(int, int)>();
            for (int i = 0; i < count; i++)
            {
                (int, int) item;
                Console.Write($"Domino #{i + 1} first number: ");
                item.Item1 = int.Parse(Console.ReadLine());
                Console.Write($"Domino #{i + 1} second number: ");
                item.Item2 = int.Parse(Console.ReadLine());

                result.Add(item);
            }

            return result;
        }

        public void Display(Chain chain)
        {
            Console.WriteLine();
            Console.WriteLine("Result:");

            var result = new StringBuilder();
            foreach(var stone in chain.Nodes)
            {
                if(stone == Stone.Invalid)
                {
                    Console.WriteLine("Chain not found");
                    return;
                }
                result.Append("[" + stone.Dots.LeftSide + "|" + stone.Dots.RightSide + "] ");
            }

            Console.WriteLine(result.ToString());
        }

        private void ContinueChain(Stone currentStone, Chain chain, StoneCollection collection)
        {
            if (_chainIsDone)
            {
                return;
            }  

            chain.AddNeighbor(collection.Grab(currentStone));

            if (collection.Stones.Count == 0 && chain.EndsMatch)
            {
                _chainIsDone = true;
                _result = chain;
            }
               
            List<Stone> possibleNextStones = collection.AllMatches(chain.OuterLeftDots, chain.OuterRightDots);
            foreach (Stone stone in possibleNextStones)
            {
                ContinueChain(stone, chain.DeepCopy(), collection.DeepCopy());
            }
        }
    }
}

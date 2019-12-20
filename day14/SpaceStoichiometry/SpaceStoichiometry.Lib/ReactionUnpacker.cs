using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStoichiometry.Lib
{
    public class ReactionUnpacker
    {
        const string FUEL = "FUEL";
        const string ORE = "ORE";
        readonly ulong _tankCapacity;
        ulong _currentTankLevel;
        IDictionary<ChemicalQuantity, IList<ChemicalQuantity>> _reactions;
        IDictionary<string, ulong> _leftovers;

        public ReactionUnpacker(IList<string> input, ulong capacity=1000000)
        {
            _reactions = new Dictionary<ChemicalQuantity, IList<ChemicalQuantity>>();

            foreach (string reaction in input) {
                int delimiter = reaction.IndexOf("=>");
                ChemicalQuantity rhs = new ChemicalQuantity(reaction.Substring(delimiter + 3).Trim());
                IList<ChemicalQuantity> lhs = reaction.Substring(0, delimiter).Split(',').Select(r => new ChemicalQuantity(r.Trim())).ToList();
                _reactions.Add(rhs, lhs);
            }

            _tankCapacity = capacity;
            _currentTankLevel = capacity;
            _leftovers = new Dictionary<string, ulong>();
        }

        public uint MaximumAmountOfFuel()
        {
            _leftovers = new Dictionary<string,ulong> ();
            _currentTankLevel = 0;
            uint units = 0;
            int magnitude = 6;
            while (true)
            {


                uint amount = (uint)Math.Pow(10, magnitude);
                var backup = _leftovers.ToDictionary(k=>k.Key, k=>k.Value);
                ulong next = Unpack(amount);
                if (_currentTankLevel + next > _tankCapacity)
                {
                    if (magnitude == 0)
                        return units;
                    magnitude--;
                    _leftovers = backup;
                    continue;
                }
                units += amount;
                _currentTankLevel += next;
            }
        }


        public ulong Unpack(uint amountOfFuelRequired=1)
        {
            IList<ChemicalQuantity> makingOneFuel = new List<ChemicalQuantity> { new ChemicalQuantity(FUEL, amountOfFuelRequired) };
            IList<ChemicalQuantity> convertibleToOre = new List<ChemicalQuantity>();
            
            while (makingOneFuel.Where(i => i.Name != ORE).Count() > 0)
            {
                ChemicalQuantity nextIngredient = makingOneFuel.Where(cq => cq.Name != ORE).First();

                var requirements = _reactions.Where(kvp => kvp.Key.Name == nextIngredient.Name).First();

                ulong leftover = 0;
                if (_leftovers.ContainsKey(nextIngredient.Name))
                {
                    leftover = _leftovers[nextIngredient.Name];
                    _leftovers.Remove(nextIngredient.Name);

                    if(leftover > nextIngredient.Quantity)
                    {
                        _leftovers.Add(nextIngredient.Name, leftover - nextIngredient.Quantity);
                        continue;
                    }
                }

                ulong lumpsOfNextIngredient = ((nextIngredient.Quantity-leftover) / requirements.Key.Quantity);
                ulong antiremainder = ((nextIngredient.Quantity-leftover) % requirements.Key.Quantity);
                if(antiremainder > 0)
                {
                    lumpsOfNextIngredient += 1;
                    _leftovers.Add(nextIngredient.Name, requirements.Key.Quantity - antiremainder);
                }
                
                makingOneFuel.Remove(nextIngredient);
                
                if(lumpsOfNextIngredient == 0)
                {
                    continue;
                }

                foreach (var item in requirements.Value)
                {
                    // if the requirement can be made from ORE, add to that pile. This allows us to be more efficient with leftovers 
                    if (item.Name == ORE)
                    {
                        // this might not work if ORE is used in conjunction with another element
                        ChemicalQuantity requirement = new ChemicalQuantity(nextIngredient.Name, nextIngredient.Quantity);
                        // that's all we need, so we can go ahead and remove it now 
                        makingOneFuel.Remove(nextIngredient);
                        ChemicalQuantity existing = convertibleToOre.Where(it => it.Name == requirement.Name).FirstOrDefault();
                        if (existing == null)
                            convertibleToOre.Add(requirement);
                        else
                            existing.Quantity += requirement.Quantity;
                    }
                    else
                    {
                        ChemicalQuantity requirement = new ChemicalQuantity(item.Name, lumpsOfNextIngredient*item.Quantity);
                        ChemicalQuantity existing = makingOneFuel.Where(it => it.Name == requirement.Name).FirstOrDefault();
                        if (existing == null)
                            makingOneFuel.Add(requirement);
                        else
                            existing.Quantity += requirement.Quantity;
                    }
                }

            }
            ulong oreQuantity = 0;
            foreach(var item in convertibleToOre)
            {
                var requirements = _reactions.Where(kvp => kvp.Key.Name == item.Name).First();
                oreQuantity += requirements.Value[0].Quantity * (item.Quantity / requirements.Key.Quantity);
                oreQuantity += item.Quantity % requirements.Key.Quantity == 0 ? 0 : requirements.Value[0].Quantity;
            }
            return oreQuantity; // makingOneFuel.Where(r => r.Name == ORE).Select(r => r.Quantity).Sum();
        }
    }

    public class ChemicalQuantity : IEquatable<ChemicalQuantity>
    {
        readonly string _name;
        ulong _quantity;

        public string Name => _name;
        public ulong Quantity { get { return _quantity; } set { _quantity = value; } }

        public ChemicalQuantity(string name, ulong quantity)
        {
            _name = name;
            _quantity = quantity;
        }

        public ChemicalQuantity(string quantity)
        {
            int space = quantity.IndexOf(' ');
            _quantity = Convert.ToUInt64(quantity.Substring(0, space).Trim());
            _name = quantity.Substring(space + 1).Trim();
        }

        public bool Equals(ChemicalQuantity other)
        {
            return _name.Equals(other.Name) && _quantity.Equals(other._quantity);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Quantity, Name);
        }
    }

}

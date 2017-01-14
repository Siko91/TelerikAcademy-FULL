using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FlowConditionalStatementsAndLoops.Task1Cooking.SupportingClasses;

namespace FlowConditionalStatementsAndLoops.Task1Cooking
{
    public class Chef
    {
        public void Cook()
        {
            Potato potato = GetPotato();
            Peel(potato);
            Cut(potato);

            Carrot carrot = GetCarrot();
            Peel(carrot);
            Cut(carrot);

            Bowl bowl = GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private void Peel(Vegetable vegetable)
        {
            vegetable.Peel();
        }

        private void Cut(Vegetable vegetable)
        {
            vegetable.Cut();
        }
    }
}
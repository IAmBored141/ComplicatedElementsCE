using Quintessential;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComplicatedElementsCE;

public static class API
{
    public struct CrystallizationRecipe //literally copy pasted from original
    {
        public CrystallizationRecipe(AtomType input, AtomType reagent, AtomType output)
        {
            this.input = input;
            this.reagent = reagent;
            this.output = output;
        }

        public bool IsMatch(AtomType input, AtomType reagent)
        {
            return this.input == input && this.reagent == reagent;
        }

        public AtomType input;
        public AtomType reagent;
        public AtomType output;
    }
    
    public static List<CrystallizationRecipe> crystalTransmutations = new(); // Input, Reagent, Output
    public static List<AtomType> CanErode = new(); 

    public static void AddTransmutations()
    {
        crystalTransmutations.Add(new(AtomTypes.air, AtomTypes.earth, Atoms.Aerolith));
        crystalTransmutations.Add(new(AtomTypes.air, AtomTypes.fire, Atoms.Ignistal));
        crystalTransmutations.Add(new(AtomTypes.air, AtomTypes.water, Atoms.Mistaline));
        crystalTransmutations.Add(new(AtomTypes.earth, AtomTypes.water, Atoms.Terramarine));
        crystalTransmutations.Add(new(AtomTypes.earth, AtomTypes.fire, Atoms.Pyrolite));
        crystalTransmutations.Add(new(AtomTypes.water, AtomTypes.fire, Atoms.Vaprorine));
        crystalTransmutations.Add(new(Atoms.Vaprorine, Atoms.Aerolith, AtomTypes.quintessence));
        crystalTransmutations.Add(new(Atoms.Mistaline, Atoms.Pyrolite, AtomTypes.quintessence));
        crystalTransmutations.Add(new(Atoms.Ignistal, Atoms.Terramarine, AtomTypes.quintessence));

        CanErode.Add(Atoms.Ignistal);
        CanErode.Add(Atoms.Aerolith);
        CanErode.Add(Atoms.Pyrolite);
        CanErode.Add(Atoms.Terramarine);
        CanErode.Add(Atoms.Mistaline);
        CanErode.Add(Atoms.Vaprorine);
    }
}

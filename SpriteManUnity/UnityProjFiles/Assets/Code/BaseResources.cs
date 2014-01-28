using UnityEngine;
using System.Collections;

namespace Assets.Code
{
    public enum BaseResources : int
    {
        Water,
        Aluminum,
        Platinum,
        Lithium,
        ExoticParticles,
        HighlyVolatileEnergy,
        LowVolativityEnergy,
        ConductiveWire,
        MetalCasing,
        HighDensityEnergyStorage,
    } ;

    public enum BaseKeys : int
    {
        common,
        uncommon,
        rare,
        legendary,
    };

    public enum Rarity : int
    {
        junk,
        common,
        uncommon,
        rare,
        legendary,
    }
}
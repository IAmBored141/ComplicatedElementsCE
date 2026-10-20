using Quintessential;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComplicatedElementsCE;

internal static class Atoms
{
    public static AtomType Aerolith, Ignistal, Mistaline, Pyrolite, Terramarine, Vaprorine;
    public static AtomType DummyQuicklime;
    public static void AddAtomTypes()
    {
        Aerolith = new()
        {
            shadow = Assets.textures.atoms.shadow,
            symbol = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/alucia/aerolith_symbol"),
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/alucia/aerolith_diffuse"),
                shade = Assets.textures.atoms.mors_shade,
            }
        };
        ComplicatedElementsCE.Instance.AddAtomType(Aerolith, "aerolith");
        Ignistal = new()
        {
            shadow = Assets.textures.atoms.shadow,
            symbol = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/alucia/ignistal_symbol"),
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/alucia/ignistal_diffuse"),
                shade = Assets.textures.atoms.mors_shade,
            }
        };
        ComplicatedElementsCE.Instance.AddAtomType(Ignistal, "ignistal");
        Mistaline = new()
        {
            shadow = Assets.textures.atoms.shadow,
            symbol = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/alucia/mistaline_symbol"),
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/alucia/mistaline_diffuse"),
                shade = Assets.textures.atoms.mors_shade,
            }
        };
        ComplicatedElementsCE.Instance.AddAtomType(Mistaline, "mistaline");
        Pyrolite = new()
        {
            shadow = Assets.textures.atoms.shadow,
            symbol = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/alucia/pyrolite_symbol"),
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/alucia/pyrolite_diffuse"),
                shade = Assets.textures.atoms.mors_shade,
            }
        };
        ComplicatedElementsCE.Instance.AddAtomType(Pyrolite, "pyrolite");
        Terramarine = new()
        {
            shadow = Assets.textures.atoms.shadow,
            symbol = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/alucia/terramarine_symbol"),
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/alucia/terramarine_diffuse"),
                shade = Assets.textures.atoms.mors_shade,
            }
        };
        ComplicatedElementsCE.Instance.AddAtomType(Terramarine, "terramarine");
        Vaprorine = new()
        {
            shadow = Assets.textures.atoms.shadow,
            symbol = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/alucia/vaprorine_symbol"),
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/alucia/vaprorine_diffuse"),
                shade = Assets.textures.atoms.mors_shade,
            }
        };
        ComplicatedElementsCE.Instance.AddAtomType(Vaprorine, "vaprorine");

        DummyQuicklime = new()
        {
            shadow = Assets.textures.atoms.shadow,
            symbol = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/erikhaag/quicklime_symbol_old"),
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/atoms/erikhaag/quicklime_diffuse_old"),
                shade = Assets.textures.atoms.salt_shade,
            }
        };
        ComplicatedElementsCE.Instance.AddAtomType(DummyQuicklime, "quicklime");
    }
}
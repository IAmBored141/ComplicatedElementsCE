using System;
using System.Collections.Generic;
using System.Text;
using Quintessential;
using static Quintessential.PartCycleDelegate;

namespace ComplicatedElementsCE;

internal class Parts
{
    public static PartType Fusion, Erosion;
    public static Texture FusionBase = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/parts/alucia/fusion/base");
    public static Texture FusionInput = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/parts/alucia/fusion/input_ring");
    public static Texture Bowl = Assets.textures.parts.calcinator_bowl;
    public static Texture FusionIcon = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/parts/alucia/icons/fusion");
    public static Texture FusionIconHover = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/parts/alucia/icons/fusion_hover");
    public static HexIndex FusionBowl = new HexIndex(0, 0);
    public static HexIndex FusionHole = new HexIndex(1, 0);

    public static Texture ErosionBase = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/parts/alucia/erosion/base");
    public static Texture ErosionBowl = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/parts/alucia/erosion/erosion_bowl");
    public static HexIndex ErosionHex = new HexIndex(0, 0);
    public static Texture ErosionIcon = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/parts/alucia/icons/erosion");
    public static Texture ErosionIconHover = AssetLoaderHelper.LoadTexture("textures/complicated_elements_ce/parts/alucia/icons/erosion_hover");
    
    public static void AddParts()
    {
        Fusion = new()
        {
            cost = 20,
            isFullHexCover = true,
            glowTexture = Assets.textures.select.double_glow,
            strokeTexture = Assets.textures.select.double_stroke,
            iconTexture = FusionIcon,
            iconHoverTexture = FusionIconHover,
            glyphHexes = new HexIndex[] { FusionBowl, FusionHole },
            permissionCategory = PuzzlePermissions.None,
            CustomPermissionCheck = perms => perms.Contains(ComplicatedElementsCE.Instance.GetIdentifier("fusion"))
        };
        ComplicatedElementsCE.Instance.AddPartType(Fusion, "fusion", (part, pos, editor, renderer) =>
        {
            renderer.RenderBase(FusionBase, Vector2.Zero, new Vector2(42f, 48f), 0f);
            renderer.RenderRotating(Bowl, FusionBowl, Vector2.Zero);
            renderer.RenderRotating(FusionInput, FusionHole, Vector2.Zero);
        });
        Erosion = new()
        {
            cost = 20,
            isFullHexCover = true,
            glowTexture = Assets.textures.select.single_glow,
            strokeTexture = Assets.textures.select.single_stroke,
            iconTexture = ErosionIcon,
            iconHoverTexture = ErosionIconHover,
            glyphHexes = new HexIndex[] { ErosionHex },
            permissionCategory = PuzzlePermissions.None,
            CustomPermissionCheck = perms => perms.Contains(ComplicatedElementsCE.Instance.GetIdentifier("erosion"))
        };
        ComplicatedElementsCE.Instance.AddPartType(Erosion, "erosion", (part, pos, editor, renderer) =>
        {
            renderer.RenderBase(ErosionBase, Vector2.Zero, new Vector2(42f, 48f), 0f);
            renderer.RenderRotating(ErosionBowl, ErosionHex, Vector2.Zero);
        });

        QApi.AddPartTypeToPanel(Fusion, false);
        QApi.AddPartTypeToPanel(Erosion, false);
        ComplicatedElementsCE.Instance.AddPuzzlePermission("fusion");
        ComplicatedElementsCE.Instance.AddPuzzlePermission("erosion");
        QApi.BindGlyphCycle(Fusion, new(PartCycleExecutionType.Normal, FusionCycle));
        QApi.BindGlyphCycle(Erosion, new(PartCycleExecutionType.Normal, ErosionCycle));
        ComplicatedElementsCE.Instance.AddRecipe(new(), Fusion.Id, Fusion.Id);
        ComplicatedElementsCE.Instance.AddRecipe(new(), Erosion.Id, Erosion.Id);
    }

    public static bool FusionCycle(Sim sim, Part part, PartSimState pss, GlyphRecipe _, bool first)
    {
        if (!sim.FindAtomRelative(part, FusionBowl).GetOrDefault(out AtomReference FuseA))
        {
            return false;
        }
        if (!sim.FindAtomRelative(part, FusionHole).GetOrDefault(out AtomReference FuseB))
        {
            return false;
        }
        if (FuseB.isHeldByArm || FuseB.inMultiAtomMolecule)
        {
            return false;
        }
        foreach (var recipe in API.crystalTransmutations)
        {
            if (recipe.input == FuseA.atomType && recipe.reagent == FuseB.atomType)
            {
                FuseB.molecule.RemoveAtom(FuseB.pos);
                FuseA.molecule.ReplaceAtom(recipe.output, FuseA.pos);
                FuseA.atom.transmutationEffect = new TransmutationEffect(sim.solutionEditor,(TransmutationEffectRenderMode)1, FuseA.atomType, Assets.textures.atoms.projection_effect, 30f);
                return true;
            }
            else if (recipe.input == FuseB.atomType && recipe.reagent == FuseA.atomType)
            {
                FuseB.molecule.RemoveAtom(FuseB.pos);
                FuseA.molecule.ReplaceAtom(recipe.output, FuseA.pos);
                FuseA.atom.transmutationEffect = new TransmutationEffect(sim.solutionEditor, (TransmutationEffectRenderMode)1, FuseA.atomType, Assets.textures.atoms.projection_effect, 30f);
                return true;
            }
        }
        return false;
    }

    public static bool ErosionCycle(Sim sim, Part part, PartSimState pss, GlyphRecipe _, bool first)
    {
        if (!sim.FindAtomRelative(part, ErosionHex).GetOrDefault(out AtomReference Input))
        {
            return false;
        }
        if (!API.CanErode.Contains(Input.atomType))
        {
            return false;
        }
        if (true)
        { //placeholder
            Input.molecule.ReplaceAtom(Atoms.DummyQuicklime, Input.pos);
        }
        else
        {
            Input.molecule.ReplaceAtom(Atoms.DummyQuicklime, Input.pos);
        }
        Input.atom.transmutationEffect = new TransmutationEffect(sim.solutionEditor, (TransmutationEffectRenderMode)0, Input.atomType, Assets.textures.atoms.calcify_mask, 30f);
        return true;
    }
}

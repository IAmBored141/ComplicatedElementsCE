using Quintessential;

namespace ComplicatedElementsCE;

internal class ComplicatedElementsCE : QuintessentialMod, IDataMod {
    public static ComplicatedElementsCE Instance { get; }
    public override string ModId => "complicated_elements_ce";

    public override void Load() { }

    public override void LoadContent() {
        Atoms.AddAtomTypes();
        API.AddTransmutations();
        Parts.AddParts();
    }
    public override void LoadCompatContent() { }
    
    public override void FinaliseContent() { }

    public override void PostLoad() { }
	public override void Unload() { }
}

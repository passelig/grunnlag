namespace GrunnlagApi.Models;

public class Innsending
{
    public required Innsender Innsender { get; set; }
    public required List<Oppgave> Oppgave { get; set; }
    public required Oppgaveoppsummering Oppgaveoppsummering { get; set; }
}

public class Innsender
{
    public required string Navn { get; set; }
    public required string Foedselsnummer { get; set; }
}

public class Oppgave
{
    public required int Saldo { get; set; }
    public required int Aksjeandel { get; set; }
}

public class Oppgaveoppsummering
{
    public required int SumSaldo { get; set; }
    public required int SumAksjehandel { get; set; }
}

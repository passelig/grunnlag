using Xunit;
using GrunnlagApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace GrunnlagApi.Tests
{
    public class InnsendingTests
    {
        [Fact]
        public void Oppsummering_Matches_Detail_Sums()
        {
            // Arrange
            var innsending = new Innsending
            {
                Innsender = new Innsender { Navn = "Ole Olsen", Foedselsnummer = "26063643458" },
                Oppgave = new List<Oppgave>
                {
                    new Oppgave { Saldo = 100, Aksjeandel = 200 },
                    new Oppgave { Saldo = 110, Aksjeandel = 210 }
                },
                Oppgaveoppsummering = new Oppgaveoppsummering
                {
                    SumSaldo = 210,
                    SumAksjehandel = 410
                }
            };

            // Act
            int actualSumSaldo = innsending.Oppgave.Sum(o => o.Saldo);
            int actualSumAksjeandel = innsending.Oppgave.Sum(o => o.Aksjeandel);

            // Assert
            Assert.Equal(innsending.Oppgaveoppsummering.SumSaldo, actualSumSaldo);
            Assert.Equal(innsending.Oppgaveoppsummering.SumAksjehandel, actualSumAksjeandel);
        }

        [Fact]
        public void Oppsummering_Does_Not_Match_Detail_Sums_Returns_Fail()
        {
            // Arrange
            var innsending = new Innsending
            {
                Innsender = new Innsender { Navn = "Kari Nordmann", Foedselsnummer = "01010112345" },
                Oppgave = new List<Oppgave>
                {
                    new Oppgave { Saldo = 50, Aksjeandel = 100 },
                    new Oppgave { Saldo = 60, Aksjeandel = 150 }
                },
                Oppgaveoppsummering = new Oppgaveoppsummering
                {
                    SumSaldo = 200,          // Incorrect on purpose
                    SumAksjehandel = 300     // Correct
                }
            };

            // Act
            int actualSumSaldo = innsending.Oppgave.Sum(o => o.Saldo);
            int actualSumAksjeandel = innsending.Oppgave.Sum(o => o.Aksjeandel);

            // Assert
            Assert.NotEqual(innsending.Oppgaveoppsummering.SumSaldo, actualSumSaldo);
            Assert.Equal(innsending.Oppgaveoppsummering.SumAksjehandel, actualSumAksjeandel);
        }
    }
}

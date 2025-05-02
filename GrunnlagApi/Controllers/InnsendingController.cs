using Microsoft.AspNetCore.Mvc;
using GrunnlagApi.Models;

namespace GrunnlagApi.Controllers
{
    [ApiController]
    [Route("grunnlag")]
    public class InnsendingController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostInnsending([FromBody] Innsending innsending)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate that the sums match
            int sumSaldo = innsending.Oppgave.Sum(o => o.Saldo);
            int sumAksjeandel = innsending.Oppgave.Sum(o => o.Aksjeandel);

            if (sumSaldo != innsending.Oppgaveoppsummering.SumSaldo ||
                sumAksjeandel != innsending.Oppgaveoppsummering.SumAksjehandel)
            {
                return BadRequest("Oppsummering stemmer ikke med detaljene.");
            }

            return Ok("Innsending mottatt");
        }
    }
}

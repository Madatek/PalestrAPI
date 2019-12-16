using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PalestrApi.Controllers
{
    public class DataController : ApiController
    {
        public List<object> Get() {
            using (EntityModel db = new EntityModel())
            {
                var prenotazioni =
                    from p in db.Prenotazione
                    join c in db.Clienti
                    on p.IdCliente equals c.Id
                    join pa in db.Palestre
                    on p.IdPalestra equals pa.Id
                    select new
                    {
                        Palestra = pa.Nome,
                        Cliente = c.Cognome,
                        Da = p.OraInizio,
                        A = p.OraFine,
                        Attrezzato = p.Attrezzato
                    };

                prenotazioni.ToList();
                return (List<object>)prenotazioni;

                
            }

        }
    }
}

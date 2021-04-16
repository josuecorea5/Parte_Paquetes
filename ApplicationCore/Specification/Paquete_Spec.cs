using ApplicationCore.Entities;
using ApplicationCore.Specification.Filters;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specification
{
    public class Paquete_Spec : Specification<Paquete>
    {
        public Paquete_Spec(Paquete_Filter filter)
        {
            Query.OrderBy(x => x.Nombre_Paquete).ThenByDescending(x => x.Id);
            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter))
                    .Take(PaginationHelper.CalculateTake(filter));
            if (!string.IsNullOrEmpty(filter.Nombre_Paquete))
            {
                Query.Search(x => x.Nombre_Paquete, "%" + filter.Nombre_Paquete + "%");
            }
        }
    }
}

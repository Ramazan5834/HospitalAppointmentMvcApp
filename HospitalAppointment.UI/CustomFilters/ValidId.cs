using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAppointment.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HospitalAppointment.UI.CustomFilters
{
    public class ValidId<TEntity> : IActionFilter where TEntity : class, new()
    {
        private readonly IGenericService<TEntity> _genericService;
        public ValidId(IGenericService<TEntity> genericService)
        {
            _genericService = genericService;
        }
        public void OnActionExecuted(ActionExecutedContext context){}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(I => I.Key == "id").FirstOrDefault();
            var id = int.Parse(dictionary.Value.ToString());
            var entity = _genericService.GetById(id);
            if (entity == null)
            {
                context.Result = new NotFoundObjectResult($"{id} değerine sahip nesne bulunamadı");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PaystackPaymentIntegration.Models.DTOs.Readonly;
using PaystackPaymentIntegration.Models.Entities;

namespace PaystackPaymentIntegration.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<transaction_record, TransactionDTO>();
        }
    }
}
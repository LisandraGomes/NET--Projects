using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Validations
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string error) : base(error) 
        { 
            
        }
        public static void When(bool temError, string mensagem)
        {
            if (temError)
                throw new DomainValidationException(mensagem);
        }
    }
}
